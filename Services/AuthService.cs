using Domain.Entities;
using Domain.IRepositories;
using Service.Abstractions;

namespace Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;

        public AuthService(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }

        public async Task<User?> VerifyUser(string email, string password)
        {
            return await _userRepo.AuthUser(email, password);
        }
    }
}
