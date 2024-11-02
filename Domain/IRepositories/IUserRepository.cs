using Domain.Entities;

namespace Domain.IRepositories
{
    public interface IUserRepository
    {
        User? AuthUser(string email, string password);
    }
}
