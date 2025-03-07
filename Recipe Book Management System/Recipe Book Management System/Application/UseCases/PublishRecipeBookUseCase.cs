using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recipe_Book_Management_System.Application.UseCases.Interfaces;
using Recipe_Book_Management_System.Domain.Entities;
using Recipe_Book_Management_System.Infrastucture.Percistence.Interfaces;

namespace Recipe_Book_Management_System.Application.UseCases
{
    class PublishRecipeBookUseCase : IPublishRecipeBookUseCase
    {
        private readonly IBookRepository _bookRepository;

        public PublishRecipeBookUseCase(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }

        public void Execute (Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));
            _bookRepository.Add(book);
        }
    }
}
