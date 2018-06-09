using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hleb.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Type { get; set; } // суп, закуска, паста, пицца
        public string Dish { get; set; } // суп - борщ, щи  пицца - маргарита, 4 сыра

    }
}
