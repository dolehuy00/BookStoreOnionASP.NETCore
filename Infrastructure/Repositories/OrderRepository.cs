using Domain.IRepositories;
using Infrastructure.DataContext;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BookDbContext _dbContext;

        public OrderRepository(BookDbContext bookDbContext)
        {
            _dbContext = bookDbContext;
        }
    }
}
