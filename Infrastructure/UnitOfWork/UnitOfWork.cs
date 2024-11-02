using Domain.Entities;
using Domain.IRepositories;
using Domain.IUnitOfWork;
using Infrastructure.DataContext;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookDbContext _context;

        public UnitOfWork(BookDbContext context)
        {
            _context = context;
            Orders = new Repository<Order>(_context);
            Books = new Repository<Book>(_context);
        }

        public IRepository<Order> Orders { get; private set; }
        public IRepository<Book> Books { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
