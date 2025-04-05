using Recipe_Book_Management_System.Application.DTOs;
using Recipe_Book_Management_System.Application.Services.Interfaces;
using Recipe_Book_Management_System.Domain.Entities;
using Recipe_Book_Management_System.Infrastucture.Percistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_Book_Management_System.Application.Services
{
    internal class RecipeBookService : IRecipeBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IRecipeRepository _recipeRepository;

        public RecipeBookService(IBookRepository bookRepository, IRecipeRepository recipeRepository)
        {
            _bookRepository = bookRepository;
            _recipeRepository = recipeRepository;
        }

        public Book PublishBook(string title, string author, string description, List<Recipe> recipes)
        {
            var book = _bookRepository.AddBook(title, author, description);

            foreach (var recipe in recipes)
            {
                _bookRepository.AddRecipeToBook(book, recipe);
            }

            return book;
        }

        public List<RecipeBookDto> GetAllBooks()
        {
            var books = _bookRepository.GetAll();

            var dtos = books.Select(b => new RecipeBookDto(b.Title, b.Author)).ToList();

            return dtos;
        }

        public Book GetBookByTitle(string title)
        {
            return _bookRepository.GetByTitle(title);
        }

        public List<RecipeDto> GetRecipesFromBook(string title)
        {
            var book = _bookRepository.GetByTitle(title);

            var recipeDtos = book.Recipes
                .Select(r => new RecipeDto(r.Title, r.Ingredients, r.Instructions))
                .ToList();

            return recipeDtos;
        }

        public List<RecipeDto> FilterRecipesByIngredient(string bookTitle, string keyword)
        {
            var book = _bookRepository.GetByTitle(bookTitle);
            if (book == null || string.IsNullOrWhiteSpace(keyword))
                return new List<RecipeDto>();

            var filtered = book.Recipes
                .Where(r =>
                    !string.IsNullOrWhiteSpace(r.Ingredients) &&
                    r.Ingredients.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .Select(r => new RecipeDto(r.Title, r.Ingredients, r.Instructions))
                .ToList();

            return filtered;
        }
    }
}
