using Recipe_Book_Management_System.Application.DTOs;
using Recipe_Book_Management_System.Application.Services.Interfaces;
using Recipe_Book_Management_System.Domain.Entities;
using Recipe_Book_Management_System.Infrastucture.Percistence;
using Recipe_Book_Management_System.Infrastucture.Percistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Recipe_Book_Management_System.Application.Services
{
    internal class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public bool CreateRecipe(string title, string ingredients, string instructions)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(ingredients) || string.IsNullOrWhiteSpace(instructions))
                return false;

            _recipeRepository.AddRecipe(title, ingredients, instructions);
            return true;
        }

        public List<RecipeDto> FilterRecipesByIngredient(string keyword)
        {
            var filtered = _recipeRepository.Filter(r =>
                !string.IsNullOrWhiteSpace(r.Ingredients) &&
                r.Ingredients.Contains(keyword, StringComparison.OrdinalIgnoreCase));

            return filtered
                .Select(r => new RecipeDto(r.Title, r.Ingredients, r.Instructions))
                .ToList();
        }
    }
}
