using Recipe_Book_Management_System.Domain.Entities;
using Recipe_Book_Management_System.Infrastucture.Percistence.Interfaces;
using System.Text.Json;

namespace Recipe_Book_Management_System.Infrastucture.Percistence
{
    class BookRepository : IBookRepository
    {
        private const string FilePath = "books.json";

        private List<Book> LoadFromFile()
        {
            if (!File.Exists(FilePath))
                return new List<Book>();

            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
        }

        private void SaveToFile(List<Book> books)
        {
            var json = JsonSerializer.Serialize(books, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        public Book AddBook(string title, string author, string description)
        {
            var books = LoadFromFile();

            var book = new Book { Title = title, Author = author, Description = description };
            books.Add(book);

            SaveToFile(books);
            return book;
        }

        public void AddRecipeToBook(Book book, Recipe recipe)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));
            if (recipe == null) throw new ArgumentNullException(nameof(recipe));

            var books = LoadFromFile();

            var existingBook = books.FirstOrDefault(b => b.Title == book.Title);
            if (existingBook == null)
                throw new InvalidOperationException($"Book with title '{book.Title}' not found.");

            existingBook.Recipes.Add(recipe);

            SaveToFile(books);
        }

        public Book GetByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be null or whitespace.", nameof(title));

            var books = LoadFromFile();

            var book = books.FirstOrDefault(b => b.Title == title);
            if (book == null)
                throw new InvalidOperationException($"Book with title '{title}' not found.");

            return book;
        }

        public List<Book> GetAll()
        {
            return LoadFromFile();
        }

        public List<Book> Filter(Func<Book, bool> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            var books = LoadFromFile();
            return books.Where(predicate).ToList();
        }
    }
}
