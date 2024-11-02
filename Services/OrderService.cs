using Domain.Entities;
using Domain.IUnitOfWork;

namespace Infrastructure.Repositories
{
    public class OrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task PlaceOrderAsync(Order order)
        {
            await _unitOfWork.Orders.AddAsync(order);

            foreach (var item in order.OrderItems!)
            {
                var book = await _unitOfWork.Books.GetByIdAsync(item.BookId);
                book!.Quantity -= item.Quantity;
            }

            await _unitOfWork.CompleteAsync();
        }
    }
}
