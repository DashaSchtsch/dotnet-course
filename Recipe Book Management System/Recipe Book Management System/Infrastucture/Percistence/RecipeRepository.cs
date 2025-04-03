using Recipe_Book_Management_System.Domain.Entities;
using Recipe_Book_Management_System.Domain.Interfaces;
using Recipe_Book_Management_System.Infrastucture.Percistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_Book_Management_System.Infrastucture.Percistence
{
    class RecipeRepository : IRecipeRepository
    {
        private readonly List<Recipe> _recipes = new List<Recipe>();

        public Recipe GetByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("No recipe with this title was found.", nameof(title));
            return _recipes.FirstOrDefault(r => r.Title == title);
        }
    }
}
