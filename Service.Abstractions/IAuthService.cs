using Domain.Entities;

namespace Service.Abstractions
{
    public interface IAuthService
    {
        Task<User?> VerifyUser(string username, string password);
    }
}
