using Recipe_Book_Management_System.Domain.Entities;

namespace Recipe_Book_Management_System.Application.UseCases.Interfaces
{
    interface IReadRecipeBookUseCase
    {
        (Book book, List<Recipe> recipes) Execute(string title);
    }
}
