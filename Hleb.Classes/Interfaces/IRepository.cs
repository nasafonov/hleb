using Hleb.Classes.Model;
using Hleb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hleb.Classes.Interfaces
{
   public interface IRepository
    {
        User AuthorizedUser { get;  }

        bool Authorize(string login, string password);
        bool RegisterUser(string name, string lastname, string email, string password);
        bool RemoveFavourite(string recipeId, int userId, string description);
        bool EditFavourite(string recipeId, int userId, string description);
        bool AddFavourite(string recipeId, int userId, string description);
        
    }
}
