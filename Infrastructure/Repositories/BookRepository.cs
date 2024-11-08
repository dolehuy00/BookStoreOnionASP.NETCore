using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _dbContext;

        public BookRepository(BookDbContext bookDbContext)
        {
            _dbContext = bookDbContext;
        }

        public async Task<Book?> Get(int bookId)
        {
            return await _dbContext.Books
                .Include(b => b.Category)
                .FirstOrDefaultAsync(b => b.Id == bookId);
        }

        public async Task<ICollection<Book>> GetAll()
        {
            return await _dbContext.Books
                .Include(b => b.Category)
                .ToListAsync();
        }

        public async Task<ICollection<Book>> SearchName(string name)
        {
            return await _dbContext.Books
                .Where(b => b.Title.Contains(name))
                .ToListAsync();
        }
    }
}
