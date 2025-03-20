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
    class ViewAllRecipeBooksUseCase : IViewAllRecipeBooksUseCase
    {
        private readonly IBookRepository _bookRepository;

        public ViewAllRecipeBooksUseCase(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }

        public IReadOnlyList<(string Title, string Author)> Execute(Func<string, bool> titleFilter = null, Func<string, bool> authorFilter = null)
        {
            var books = _bookRepository.GetAll();

            if (titleFilter != null)
            {
                books = books.Where(book => titleFilter(book.Title)).ToList();
            }

            if (authorFilter != null)
            {
                books = books.Where(book => authorFilter(book.Author)).ToList();
            }

            return books;
        }
    }
}
