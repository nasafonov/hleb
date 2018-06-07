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
        IEnumerable<Recipe> Recipes { get; }
        IEnumerable<Favourite> Favourites { get; }
        User AuthorizedUser { get; }

        bool Authorize(string login, string password);
        bool RegisterUser(string name, string email, string login, string password);
        bool RemoveF(Favourite favourite);
        bool EditdF(Favourite favourite, string description);
        bool AddF(Recipe station, string description);
        
    }
}
