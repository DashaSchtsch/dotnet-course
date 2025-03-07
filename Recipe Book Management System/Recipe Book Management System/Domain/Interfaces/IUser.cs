using Recipe_Book_Management_System.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_Book_Management_System.Domain.Interfaces
{
    interface IUser
    {
        public int UserID { get; }
        public string Name { get; }
        IReadOnlyList<Book> Books { get; }
        void AddUserBook(Book book);
    }
}
