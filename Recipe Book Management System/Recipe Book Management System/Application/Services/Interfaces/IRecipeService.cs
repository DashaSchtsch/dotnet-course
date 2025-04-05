using Recipe_Book_Management_System.Application.DTOs;
using Recipe_Book_Management_System.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_Book_Management_System.Application.Services.Interfaces
{
    internal interface IRecipeService
    {
        bool CreateRecipe(string title, string ingredients, string instructions);
        List<RecipeDto> FilterRecipesByIngredient(string keyword);
    }
}
