using GameLoanApi.Data.Repositories.Interfaces;
using GameLoanApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GameLoanApi.Data.Repositories
{
    public class AuthRepository: IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByUsername(string userName)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Username == userName);
        }

        public async Task Register(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
