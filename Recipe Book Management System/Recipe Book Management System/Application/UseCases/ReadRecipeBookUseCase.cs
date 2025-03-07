using Recipe_Book_Management_System.Application.UseCases.Interfaces;
using Recipe_Book_Management_System.Domain.Entities;
using Recipe_Book_Management_System.Infrastucture.Percistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_Book_Management_System.Application.UseCases
{
    class ReadRecipeBookUseCase : IReadRecipeBookUseCase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IRecipeRepository _recipeRepository;
        public ReadRecipeBookUseCase(IBookRepository bookRepository, IRecipeRepository recipeRepository)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            _recipeRepository = recipeRepository ?? throw new ArgumentNullException(nameof(recipeRepository));
        }
        public (Book book, List<Recipe> recipes) Execute(string title)
        {
            var book = GetBookByTitle(title);
            if (book == null) return (null, null);

            var recipes = GetRecipesForBook(book);
            return (book, recipes);
        }

        private Book GetBookByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Book title cannot be empty.", nameof(title));

            return _bookRepository.GetByTitle(title);
        }

        private List<Recipe> GetRecipesForBook(Book book)
        {
            return book.Recipes
                .Select(recipe => _recipeRepository.GetByTitle(recipe.Title))
                .Where(r => r != null)
                .ToList();
        }
    }
}
