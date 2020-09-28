using GameLoanDomain.Entities;
using System.Threading.Tasks;

namespace GameLoanDomain.Repositories
{
    public interface IAuthRepository
    {
        Task Register(User user);
        Task<User> GetUserByUsername(string userName);
    }
}
