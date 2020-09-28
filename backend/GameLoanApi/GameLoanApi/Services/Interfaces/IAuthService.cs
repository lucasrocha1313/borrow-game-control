using GameLoanApi.Entities;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GameLoanApi.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string userName, string password);
        object GenerateToken(User user);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        bool IsUnauthorized(ClaimsPrincipal User, int userId);
    }
}
