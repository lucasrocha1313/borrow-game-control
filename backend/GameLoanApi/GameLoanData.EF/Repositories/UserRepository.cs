using GameLoanData.EF.Context;
using GameLoanDomain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GameLoanData.EF.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> UserExists(string userName)
        {
            if (await _context.User.AnyAsync(u => u.Username.Equals(userName)))
                return true;

            return false;
        }
    }
}
