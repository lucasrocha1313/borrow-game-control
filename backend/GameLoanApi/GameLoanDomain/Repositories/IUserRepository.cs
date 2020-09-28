using System.Threading.Tasks;

namespace GameLoanDomain.Repositories
{
    public interface IUserRepository
    {
        Task<bool> UserExists(string userName);
    }
}
