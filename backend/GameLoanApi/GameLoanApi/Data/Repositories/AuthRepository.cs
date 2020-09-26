using GameLoanApi.Data.Repositories.Interfaces;
using GameLoanApi.Entities;
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

        public async Task Register(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        }
    }
}
