using Recipe_Book_Management_System.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_Book_Management_System.Domain.Interfaces
{
    interface IBook
    {
        string Title { get; }
        string Author { get; }
        string Description { get; }
        IReadOnlyList<Recipe> Recipes { get; }
        void AddRecipe(Recipe recipe);
    }
}
