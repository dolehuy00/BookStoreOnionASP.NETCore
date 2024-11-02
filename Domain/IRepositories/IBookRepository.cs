using Domain.Entities;

namespace Domain.IRepositories
{
    public interface IBookRepository
    {
        Task<ICollection<Book>> GetAll();
        Task<Book?> Get(int bookId);
    }
}
