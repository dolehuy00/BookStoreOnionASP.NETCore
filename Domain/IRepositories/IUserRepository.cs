using Domain.Entities;

namespace Domain.IRepositories
{
    public interface IUserRepository
    {
        Task<User?> AuthUser(string email, string password);
    }
}
