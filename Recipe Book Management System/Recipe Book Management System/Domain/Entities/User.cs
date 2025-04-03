using System;
using System.Collections.Generic;

namespace Recipe_Book_Management_System.Domain.Entities
{
    class User : BaseUser
    {
        public User(int userId, string name) : base(userId, name)
        {
        }
    }
}
