using Hleb.Classes.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Hleb.Classes.MainLogic
{
    public interface ILogic
    {
        List<string> Reader(string uri);
    }
    public class Json : ILogic
    {
        public List<string> Reader(string uri)
        {
            List<string> _ingr = new List<string>();
            using (var sr = new StreamReader(uri))
            {
                using (var reader = new JsonTextReader(sr))
                {
                    var serializer = new JsonSerializer();
                    List<Ingredients> ingr = serializer.Deserialize<List<Ingredients>>(reader);
                    foreach (var ing in ingr)
                        _ingr.Add(ing.Name);
                    return _ingr;
                }
            }
        }     
    }
}
