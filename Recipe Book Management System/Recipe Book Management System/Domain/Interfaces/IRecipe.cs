using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_Book_Management_System.Domain.Interfaces
{
    interface IRecipe
    {
        public string Title { get; }
        public string Ingredients { get; }
        public string Instructions { get; }
    }
}
