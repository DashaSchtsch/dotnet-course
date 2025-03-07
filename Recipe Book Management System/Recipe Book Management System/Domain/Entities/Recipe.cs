using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recipe_Book_Management_System.Domain.Interfaces;

namespace Recipe_Book_Management_System.Domain.Entities
{
    class Recipe : IRecipe
    {
        public string Title { get; private set; }
        public string Ingredients { get; private set; }
        public string Instructions { get; private set; }

        public Recipe(string title, string ingredients, string instructions)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Recipe title cannot be empty.", nameof(title));
            if (string.IsNullOrWhiteSpace(ingredients))
                throw new ArgumentException("Recipe ingredients cannot be empty.", nameof(ingredients));
            if (string.IsNullOrWhiteSpace(instructions))
                throw new ArgumentException("Recipe instructions cannot be empty.", nameof(instructions));

            Title = title;
            Ingredients = ingredients;
            Instructions = instructions;
        }
    }
}
