using GameLoanDomain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameLoanDomain.Repositories
{
    public interface IGameReposistory
    {
        Task Add(List<GameUser> games);
        IEnumerable<GameUser> GetByUser(int userId);
    }
}
