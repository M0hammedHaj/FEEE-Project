using FEEE.Domain.Interfaces;
using FEEE.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEEE.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserModel>> GetAllAsync()
        {
            return await _context.Users
                .Select(u => new UserModel
                {
                    UserId = u.UserId,
                    Username = u.Username,
                    Password = u.Password,
                    Role = u.Role
                })
                .ToListAsync();
        }

        public async Task<UserModel?> GetByIdAsync(int id)
        {
            return await _context.Users
                .Where(u => u.UserId == id)
                .Select(u => new UserModel
                {
                    UserId = u.UserId,
                    Username = u.Username,
                    Password = u.Password,
                    Role = u.Role
                })
                .FirstOrDefaultAsync();
        }

        public async Task AddAsync(UserModel model)
        {
            var entity = new Infrastructure.Persistence.Entities.User
            {
                Username = model.Username,
                Password = model.Password,
                Role = model.Role
            };

            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Users.FindAsync(id);
            if (entity == null)
                return;

            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
        }

    }
}
