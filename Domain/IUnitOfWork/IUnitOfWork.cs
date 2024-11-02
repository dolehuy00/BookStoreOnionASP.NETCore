using Domain.Entities;
using Domain.IRepositories;

namespace Domain.IUnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Order> Orders { get; }
        IRepository<Book> Books { get; }
        Task<int> CompleteAsync();
    }
}
