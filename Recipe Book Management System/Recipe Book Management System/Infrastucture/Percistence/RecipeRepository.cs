using Recipe_Book_Management_System.Domain.Entities;
using Recipe_Book_Management_System.Infrastucture.Percistence.Interfaces;
using System.Text.Json;

namespace Recipe_Book_Management_System.Infrastucture.Percistence
{
    class RecipeRepository : IRecipeRepository
    {
        private const string FilePath = "recipes.json";

        private List<Recipe> LoadFromFile()
        {
            if (!File.Exists(FilePath))
                return new List<Recipe>();

            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<Recipe>>(json) ?? new List<Recipe>();
        }

        private void SaveToFile(List<Recipe> recipes)
        {
            var json = JsonSerializer.Serialize(recipes, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        public Recipe AddRecipe(string title, string ingredients, string instructions)
        {
            var recipes = LoadFromFile();
            var recipe = new Recipe { Title = title, Ingredients = ingredients, Instructions = instructions };
            recipes.Add(recipe);
            SaveToFile(recipes);
            return recipe;
        }

        public List<Recipe> GetAll()
        {
            return LoadFromFile();
        }

        public Recipe GetByTitle(string title)
        {
            var recipes = LoadFromFile();
            return recipes.FirstOrDefault(r => r.Title == title);
        }

        public List<Recipe> Filter(Func<Recipe, bool> predicate)
        {
            var recipes = LoadFromFile();
            return recipes.Where(predicate).ToList();
        }
    }
}
