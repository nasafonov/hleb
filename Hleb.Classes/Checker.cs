using Hleb.Classes.Model;
using Hleb.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hleb.Classes
{
   public class Checker
    {
        public Checker()
        {
            //var users = new List<User>();
            //GetSpeakers(users);
            GetFavourites();
        }
        private void GetFavourites()
        {
            var favouriteJsonAll =
                GetEmbeddedResourceAsString("Hleb.Classes.Data.favourites.json");
            var Favourites = new List<Favourite>();
            JArray jsonValFavourites = JArray.Parse(favouriteJsonAll) as JArray;
            dynamic favouritesData = jsonValFavourites;
            foreach (dynamic favourite in favouritesData)
            {
                var Favourite = new Favourite
                {
                    Id = favourite.Id,
                    RecipeId = favourite.RecipeId,
                    UserId = favourite.UserId,
                    Description = favourite.Description
                };
               
                Favourites.Add( Favourite);

            }
        }


        private string GetEmbeddedResourceAsString(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            //var names = assembly.GetManifestResourceNames();

            string result;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }
    }
}
