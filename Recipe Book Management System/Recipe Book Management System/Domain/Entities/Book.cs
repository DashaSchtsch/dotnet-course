using System;
using System.Collections.Generic;
using Recipe_Book_Management_System.Domain.Interfaces;

namespace Recipe_Book_Management_System.Domain.Entities
{
    class Book : IBook
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string Description { get; private set; }

        private List<Recipe> _recipes = new();
        public IReadOnlyList<Recipe> Recipes => _recipes;

        public Book(string title, string author, string description, List<Recipe> recipes)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Book title cannot be empty.", nameof(title));
            if (string.IsNullOrWhiteSpace(author))
                throw new ArgumentException("Book author cannot be empty.", nameof(author));
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Book description cannot be empty.", nameof(description));
            if (!recipes.Any())
                throw new ArgumentException("A recipe book must have at least one recipe.", nameof(recipes));

            Title = title;
            Author = author;
            Description = description;
            _recipes = recipes;
        }

        public void AddRecipe(Recipe recipe)
        {
            if (recipe == null)
                throw new ArgumentNullException(nameof(recipe));

            _recipes.Add(recipe);
        }
    }
}
