using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hleb.Model
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URLdescription { get; set; }
        public string URLimage { get; set; }
        public List<string> Ingredients { get; set; }
        public double Rating { get; set; }

    }
}
