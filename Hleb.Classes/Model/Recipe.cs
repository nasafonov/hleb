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
        public Category Category { get; set; }
        public string Description { get; set; }
        public string Instruction { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public double Rating { get; set; }

    }
}
