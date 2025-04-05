using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_Book_Management_System.Domain.Entities
{
    class Recipe
    {
        public string Title { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
    }
}
