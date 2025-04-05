using Recipe_Book_Management_System.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_Book_Management_System.Infrastucture.Percistence.Interfaces
{
    interface IRecipeRepository
    {
        Recipe AddRecipe(string title, string ingredients, string instructions);
        Recipe GetByTitle(string title);
        List<Recipe> GetAll();
        List<Recipe> Filter(Func<Recipe, bool> predicate);
    }
}
