using Recipe_Book_Management_System.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_Book_Management_System.Domain.Entities
{
    abstract class BaseUser : IUser
    {
        public int UserID { get; private set; }
        public string Name { get; private set; }
        protected List<Book> _books = new();
        public IReadOnlyList<Book> Books => _books;

        protected BaseUser(int userId, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("User name cannot be empty.", nameof(name));

            UserID = userId;
            Name = name;
        }

        public void AddUserBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            _books.Add(book);
        }
    }
}
