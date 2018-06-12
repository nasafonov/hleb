﻿using Hleb.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hleb.Classes.Model
{
    public class Favourite
    {
        public int Id { get; set; }
        public string RecipeId { get; set; }
       // [NotMapped]
        public int UserId { get; set; }
        public string Description { get; set; }

    }
}
