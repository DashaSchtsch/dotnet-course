using Recipe_Book_Management_System.Application.DTOs;
using Recipe_Book_Management_System.Domain.Entities;
using Recipe_Book_Management_System.Infrastucture.Percistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_Book_Management_System.Application.Services.Interfaces
{
    internal interface IRecipeBookService
    {
        Book PublishBook(string title, string author, string description, List<Recipe> recipes);
        List<RecipeBookDto> GetAllBooks();
        Book GetBookByTitle(string title);
        List<RecipeDto> GetRecipesFromBook(string title);
        List<RecipeDto> FilterRecipesByIngredient(string bookTitle, string keyword);
    }
}
