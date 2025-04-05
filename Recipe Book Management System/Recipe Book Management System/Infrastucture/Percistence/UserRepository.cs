using Recipe_Book_Management_System.Domain.Entities;
using Recipe_Book_Management_System.Infrastucture.Percistence.Interfaces;
using System.Text.Json;

namespace Recipe_Book_Management_System.Infrastucture.Percistence
{
    class UserRepository : IUserRepository
    {
        private const string FilePath = "users.json";

        private List<User> LoadFromFile()
        {
            if (!File.Exists(FilePath))
                return new List<User>();

            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }

        private void SaveToFile(List<User> users)
        {
            var json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        public User AddUser(string name)
        {
            var users = LoadFromFile();
            var newId = users.Count > 0 ? users.Max(u => u.UserID) + 1 : 1;

            var user = new User { UserID = newId, Name = name };
            users.Add(user);

            SaveToFile(users);
            return user;
        }

        public User GetById(int userId)
        {
            var users = LoadFromFile();
            return users.FirstOrDefault(u => u.UserID == userId);
        }

        public List<User> Filter(Func<User, bool> predicate)
        {
            var users = LoadFromFile();
            return users.Where(predicate).ToList();
        }
    }
}
