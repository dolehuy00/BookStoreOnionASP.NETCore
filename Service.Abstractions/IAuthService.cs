using Domain.Entities;

namespace Service.Abstractions
{
    public interface IAuthService
    {
        User? Authenticate(string username, string password);
    }
}
