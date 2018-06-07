using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hleb.Model
{
    public class Ingredient
    {
        public string Name { get; set; }
        public List<Recipe> Recipes { get; set; }
    }
}
