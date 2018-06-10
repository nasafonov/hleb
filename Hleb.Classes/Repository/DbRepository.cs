using Hleb.Classes.Helpers;
using Hleb.Classes.Model;
using Hleb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hleb.Classes
{
    public class DbRepository
    {
        private List<User> Users { get; set; }
        
        public IEnumerable<Favourite> Favourites { get; }
        public User AutorisedUser { get; set; }
        public IList<User> usersdata => Users;

        private Context context;

        public DbRepository()
        {
            context = new Context();
            RestoreData();
        }

        public void RestoreData()
        {
            Users = context.Users.ToList();
        }

        public bool RegisterUser(string name, string email,  string password)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("User name cannot be empty");
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("User email cannot be empty");
            if (string.IsNullOrWhiteSpace(PasswordHelpers.GetHash(password)))
                throw new ArgumentException("User password cannot be empty");

            if (context.Users.FirstOrDefault(u => u.Email == email) == null)
            {
                var user = new User()
                {
                    Name = name,
                    Email = email,
                    Password = PasswordHelpers.GetHash(password),
                    Favourites = new List<Favourite>()
                };
                Users.Add(user);
                context.Users.Add(user);
                context.SaveChanges();
                return true;
            }
            else
                return false;
        }


        public bool Authorize(string login, string password)
        {
            var user = context.Users.FirstOrDefault(u => u.Email == login && u.Password == PasswordHelpers.GetHash(password));
            if (user!=null)
            {
                AutorisedUser = user;
                return true;
            }
            else
                return false;
        }
    }
}
