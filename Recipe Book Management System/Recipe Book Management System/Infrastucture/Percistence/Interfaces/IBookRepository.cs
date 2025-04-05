using Recipe_Book_Management_System.Application.DTOs;
using Recipe_Book_Management_System.Domain.Entities;

namespace Recipe_Book_Management_System.Infrastucture.Percistence.Interfaces
{
    interface IBookRepository
    {
        Book AddBook(string title, string author, string description);
        void AddRecipeToBook(Book book, Recipe recipe);
        Book GetByTitle(string title);
        List<Book> GetAll();
        List<Book> Filter(Func<Book, bool> predicate);
    }
}
