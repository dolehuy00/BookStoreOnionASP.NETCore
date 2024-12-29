using Domain.Entities;
using Domain.IRepositories;
using Service.Abstractions;
using Services.Mapper;
using Shared;
using System.Linq.Expressions;

namespace Services
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _genericRepo;
        private readonly IBookRepository _bookRepo;
        private readonly BookMapper _bookMapper;

        public BookService(IRepository<Book> genericRepo, BookMapper _mapper, IBookRepository bookRepo)
        {
            _genericRepo = genericRepo;
            _bookRepo = bookRepo;
            _bookMapper = _mapper;
        }

        public async Task<BookDTO> Add(BookDTO bookDTO)
        {
            var book = _bookMapper.ToEntity(bookDTO);
            _genericRepo.Add(book);
            await _genericRepo.SaveChangesAsync();
            bookDTO.Id = book.Id;
            return bookDTO;
        }

        public async Task Delete(int bookId)
        {
            _genericRepo.Delete(bookId);
            await _genericRepo.SaveChangesAsync();
        }

        public async Task<BookDTO?> Get(int bookId)
        {
            var book = await _genericRepo.GetByIdAsync(bookId);
            if (book == null) return null;
            return _bookMapper.ToDTO(book);
        }

        public async Task<ICollection<Book>> GetAll()
        {
            return await _genericRepo.GetAllAsync();
        }

        public async Task Update(BookDTO bookDTO)
        {
            var book = _bookMapper.ToEntity(bookDTO);
            _genericRepo.Update(book);
            await _genericRepo.SaveChangesAsync();
        }

        public async Task<ICollection<BookDTO>> Find()
        {
            Expression<Func<Book, bool>> filter = b => b.Price > 100;

            var expensiveBooks = await _genericRepo.FindAsync(filter);
            return _bookMapper.ToListDTO(expensiveBooks);
        }

        public async Task<ICollection<BookDTO>> GetAllFullInfo()
        {
            var books = await _bookRepo.GetAll();
            return _bookMapper.ToListDTO(books);
        }

        public async Task<BookDTO?> GetFullInfo(int bookId)
        {
            var book = await _bookRepo.Get(bookId);
            if (book == null) return null;
            return _bookMapper.ToDTO(book);
        }

        public async Task<ICollection<BookDTO>> SearchName(string name)
        {
            if (string.IsNullOrEmpty(name)) name = "";
            var books = await _genericRepo.FindAsync(b => b.Title.Contains(name));
            return _bookMapper.ToListDTO(books);
        }
    }
}
