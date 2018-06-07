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
        public IEnumerable<Recipe> Recipes { get; }
        public IEnumerable<Favourite> Favourites { get; }
        public User AuthorizedUser { get; }

        public bool RegisterUser(string name, string email,  string password)
        {
            var user = new User()
            {
                Name = name,
                Email = email,
                Password = PasswordHelpers.GetHash(password),
                Favourites = new List<Favourite>()
            };
           
            var DbRepository = new DbRepository();
            return true;
        }


        public bool Authorize(string login, string password)
        {
            
            return false;
        }
    }
}
