using Domain.Entities;
using Shared;

namespace Service.Abstractions
{
    public interface IBookService
    {
        Task<BookDTO> Add(BookDTO book);
        Task Update(BookDTO bookDTO);
        Task Delete(int bookId);
        Task<ICollection<Book>> GetAll();
        Task<BookDTO?> Get(int bookId);
        Task<ICollection<BookDTO>> GetAllFullInfo();
        Task<BookDTO?> GetFullInfo(int bookId);
        Task<ICollection<BookDTO>> SearchName(string name);
    }
}
