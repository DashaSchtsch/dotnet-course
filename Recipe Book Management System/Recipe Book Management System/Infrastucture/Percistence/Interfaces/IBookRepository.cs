using Recipe_Book_Management_System.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_Book_Management_System.Infrastucture.Percistence.Interfaces
{
    interface IBookRepository
    {
        void Add(Book book);
        Book GetByTitle(string title);
        IReadOnlyList<(string Title, string Author)> GetAll();
    }
}
