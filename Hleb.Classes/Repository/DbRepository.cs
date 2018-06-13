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
using System.Windows;

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
            {
                MessageBox.Show("User name cannot be empty");
                return false;
            }
            if (string.IsNullOrWhiteSpace(lastname))
            {
                MessageBox.Show("User lastname cannot be empty");
                return false;
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("User email cannot be empty");
                return false;
            }
            if (string.IsNullOrWhiteSpace(PasswordHelpers.GetHash(password)))
            {
                MessageBox.Show("User password cannot be empty");
                return false;
            }
            

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


        public bool Authorize(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("User email cannot be empty");
                return false;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("User password cannot be empty");
                return false;
            }
            password = PasswordHelpers.GetHash(password);
            var user = context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user!=null)
            {
                AuthorizedUser = user;
                if (AuthorizedUser.Favourites == null)
                    AuthorizedUser.Favourites = new List<Favourite>();

                return true;
            }
            else
                return false;
        }

        public bool RemoveFavourite(string recipeId, int userId, string description)
        {
            if (string.IsNullOrWhiteSpace(recipeId))
            {
                MessageBox.Show("Please choose recipe");
                return false;
            }
            _repo = GetJsRepository();
            var favourite = _repo.Favourites.FirstOrDefault(f => f.RecipeId == recipeId && f.UserId == userId);
            if (favourite != null)
            {
                _repo.Favourites.Remove(favourite);
                _repo.Save();
                favourite = AuthorizedUser.Favourites.FirstOrDefault(f => f.RecipeId == recipeId && f.UserId == userId);
                AuthorizedUser.Favourites.Remove(favourite);
                favourite = context.Favourites.FirstOrDefault(f => f.RecipeId == recipeId && f.UserId == userId);
                context.Favourites.Remove(favourite);
                context.SaveChanges();
                return true;
            }
            else
            {
                MessageBox.Show("There is not favourites like it. Check the currency of the inpuy data");
                return false;
            }
        }


        public bool AddFavourite(string recipeId, int userId, string description)
        {
            if (string.IsNullOrWhiteSpace(recipeId))
            {
                MessageBox.Show("Please choose recipe");
                return false;
            }
            var fav = new Favourite { RecipeId = recipeId, UserId = userId, Description = description };
            AuthorizedUser.Favourites.Add(fav);
            context.Favourites.Add(fav);
            context.SaveChanges();
            _repo = GetJsRepository();
            _repo.Favourites.Add(fav);
            _repo.Save();
            return true;
        }

        public bool EditFavourite(string recipeId, int userId, string description)
        {
            if (string.IsNullOrWhiteSpace(recipeId))
            {
                MessageBox.Show("Please choose recipe");
                return false;
            }
            _repo = GetJsRepository();
            var favourite = _repo.Favourites.FirstOrDefault(f => f.RecipeId == recipeId && f.UserId == userId);
            if (favourite != null)
            {
                favourite.Description = description;
                _repo.Save();
                favourite = AuthorizedUser.Favourites.FirstOrDefault(f => f.RecipeId == recipeId && f.UserId == userId);
                favourite.Description = description;
                favourite = context.Favourites.FirstOrDefault(f => f.RecipeId == recipeId && f.UserId == userId);
                favourite.Description = description;
                context.SaveChanges();
                return true;
            }
            else
            {
                MessageBox.Show("There is not favourites like it. Check the currency of the inpuy data");
                return false;
            }
        }
    }
}
