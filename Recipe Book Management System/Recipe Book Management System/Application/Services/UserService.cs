using Recipe_Book_Management_System.Domain.Entities;
using Recipe_Book_Management_System.Infrastucture.Percistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_Book_Management_System.Application.Services
{
    internal class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool RegisterUser(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            _userRepository.AddUser(name);
            return true;
        }
    }
}
