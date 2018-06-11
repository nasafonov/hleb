using Hleb.Classes.Model;
using Hleb.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hleb.Classes.Repository
{
    public class JsRepository
    {
        public List<User> Users { get; set; }
        private List<Favourite> Favourites { get; set; }

        public User AutorisedUser { get; set; }

        public JsRepository(string users, string favourites)
        {
            //Users = new List<User>() { new User { Id = 1, Email = "1", Password = "1", Name = "Name" } };
            //Favourites = new List<Favourite>() { new Favourite { Description = "nyam", UserId = 1, Id = 1 } };
            //Save();
            RestoreFiles();
        }

        public void RestoreFiles()
        {
            Favourites = RestoreList<Favourite>("favourites.json");
            Users = RestoreList<User>("users.json");
            foreach (var user in Users)
            {
                user.Favourites = new List<Favourite>();
                foreach (Favourite f in Favourites)
                {
                    if (user.Id == f.UserId)
                        user.Favourites.Add(f);
                }
            }            
        }


        public List<T> RestoreList<T>(string fileName)
        {
            using (var sr = new StreamReader(fileName))
            {
                using (var reader = new JsonTextReader(sr))
                {
                    var serializer = new JsonSerializer();
                    return serializer.Deserialize<List<T>>(reader);
                }
            }
        }
        public void SaveList<T>(string fileName, List<T> list)
        {
            using (var sw = new StreamWriter(fileName))
            {
                using (var writer = new JsonTextWriter(sw))
                {
                    writer.Formatting = Formatting.Indented;
                    var serializer = new JsonSerializer();
                    serializer.Serialize(writer, list);
                }
            }
        }

        public void Save()
        {
            SaveList("users.json", Users);
            SaveList("favourites.json", Favourites);
        }
    }
}
