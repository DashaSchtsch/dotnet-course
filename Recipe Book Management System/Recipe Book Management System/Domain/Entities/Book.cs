namespace Recipe_Book_Management_System.Domain.Entities
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }

        public List<Recipe> Recipes = new List<Recipe>();
    }
}
