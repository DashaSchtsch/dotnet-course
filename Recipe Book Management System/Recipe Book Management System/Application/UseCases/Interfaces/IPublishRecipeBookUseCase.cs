using Recipe_Book_Management_System.Domain.Entities;

namespace Recipe_Book_Management_System.Application.UseCases.Interfaces
{
    interface IPublishRecipeBookUseCase
    {
        void Execute(Book book);
    }
}
