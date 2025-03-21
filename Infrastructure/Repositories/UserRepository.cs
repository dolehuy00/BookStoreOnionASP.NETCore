﻿using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BookDbContext _dbContext;

        public UserRepository(BookDbContext bookDbContext)
        {
            _dbContext = bookDbContext;
        }
        public async Task<User?> AuthUser(string email, string password)
        {
            return await _dbContext.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }
    }
}
