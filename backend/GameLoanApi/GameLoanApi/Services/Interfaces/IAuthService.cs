using GameLoanApi.Entities;
using System.Threading.Tasks;

namespace GameLoanApi.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string userName, string password);
    }
}
