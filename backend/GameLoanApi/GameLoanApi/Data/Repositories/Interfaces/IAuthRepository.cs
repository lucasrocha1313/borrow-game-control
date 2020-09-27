using GameLoanApi.Entities;
using System.Threading.Tasks;

namespace GameLoanApi.Data.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task Register(User user);
        Task<User> GetUserByUsername(string userName);
    }
}
