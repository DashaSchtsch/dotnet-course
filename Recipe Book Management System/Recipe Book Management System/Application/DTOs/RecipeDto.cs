namespace Recipe_Book_Management_System.Application.DTOs
{
    class RecipeDto
    {
        public string Title { get; }
        public string Ingredients { get; }
        public string Instructions { get; }

        public RecipeDto(string title, string ingredients, string instructions)
        {
            Title = title;
            Ingredients = ingredients;
            Instructions = instructions;
        }
    }
}
