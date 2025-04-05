using System;
using System.Collections.Generic;

namespace Recipe_Book_Management_System.Domain.Entities
{
    class User : BaseUser
    {
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
