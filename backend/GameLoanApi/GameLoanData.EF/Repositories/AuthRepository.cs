using GameLoanData.EF.Context;
using GameLoanDomain.Entities;
using GameLoanDomain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GameLoanData.EF.Repositories
{
    public class AuthRepository : IAuthRepository
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
