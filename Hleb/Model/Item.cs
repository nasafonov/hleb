using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hleb.Model
{
    class Item
    {
        public Recipe SelectedRecipe { get; set; }
        public Catalog Catalog { get; set; }
    }
}
