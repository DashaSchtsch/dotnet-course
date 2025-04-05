namespace Recipe_Book_Management_System.Application.DTOs
{
    class RecipeBookDto
    {
        public string Title { get; }
        public string Author { get; }

        public RecipeBookDto(string title, string author)
        {
            Title = title;
            Author = author;
        }
    }
}
