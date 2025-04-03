using Recipe_Book_Management_System.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_Book_Management_System.Application.UseCases.Interfaces
{
    interface IViewAllRecipeBooksUseCase
    {
        IReadOnlyList<(string Title, string Author)> Execute();
    }
}
