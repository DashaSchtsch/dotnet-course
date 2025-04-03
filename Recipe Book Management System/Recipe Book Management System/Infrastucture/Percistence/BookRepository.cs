using Recipe_Book_Management_System.Domain.Entities;
using Recipe_Book_Management_System.Infrastucture.Percistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_Book_Management_System.Infrastucture.Percistence
{
    class BookRepository : IBookRepository
    {
        private readonly List<Book> _books = new List<Book>();
        public void Add(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));
            if (_books.Any(b => b.Title == book.Title))
                throw new InvalidOperationException($"A book with the title '{book.Title}' already exists.");
            _books.Add(book);
        }

        public Book GetByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("No book with this title was found.", nameof(title));
            return _books.FirstOrDefault(b => b.Title == title);
        }
        public IReadOnlyList<(string Title, string Author)> GetAll()
        {
            return _books.Select(b => (b.Title, b.Author)).ToList().AsReadOnly();
        }
    }
}
