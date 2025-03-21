using Recipe_Book_Management_System.Domain.Entities;
using Recipe_Book_Management_System.Infrastucture.Percistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_Book_Management_System.Infrastucture.Percistence
{
    class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new();

        public User GetById(int userId)
        {
            return _users.FirstOrDefault(u => u.UserID == userId);
        }
    }
}
