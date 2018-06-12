using Hleb.Classes.Helpers;
using Hleb.Classes.Interfaces;
using Hleb.Classes.Model;
using Hleb.Classes.Repository;
using Hleb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hleb.Classes
{
    public class DbRepository: IRepository
    {
        private List<User> Users { get; set; }
        
        public IEnumerable<Favourite> Favourites { get; }
        public User AuthorizedUser { get; private set; }
        public IList<User> usersdata => Users;

        private Context context;
        private JsRepository _repo;

        private JsRepository GetJsRepository() => _repo ?? (_repo = new JsRepository());

        public DbRepository()
        {
            context = new Context();
            RestoreData();
        }

        public void RestoreData()
        {
            Users = context.Users.ToList();
        }

        public bool RegisterUser(string name, string lastname, string email,  string password)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("User name cannot be empty");
            if (string.IsNullOrWhiteSpace(lastname))
                throw new ArgumentException("User lastname cannot be empty");
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("User email cannot be empty");
            if (string.IsNullOrWhiteSpace(PasswordHelpers.GetHash(password)))
                throw new ArgumentException("User password cannot be empty");

            if (context.Users.FirstOrDefault(u => u.Email == email) == null)
            {
                var user = new User()
                {
                    Name = name,
                    LastName = lastname,
                    Email = email,
                    Password = PasswordHelpers.GetHash(password),
                    Favourites = new List<Favourite>()
                };
                Users.Add(user);
                context.Users.Add(user);
                context.SaveChanges();
                _repo = GetJsRepository();
                _repo.Users.Add(user);
                _repo.Save();
                return true;
            }
            else
                return false;
        }


        public bool Authorize(string login, string password)
        {
            password = PasswordHelpers.GetHash(password);
            var user = context.Users.FirstOrDefault(u => u.Email == login && u.Password == password);
            if (user!=null)
            {
                AuthorizedUser = user;
                return true;
            }
            else
                return false;
        }
    }
}
