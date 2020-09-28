using GameLoanDomain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameLoanDomain.Repositories
{
    public interface IGameLentRepository
    {
        Task LendGames(List<GameLent> gameToLent);
        IEnumerable<GameLent> GetLentGamesByUserGameId(IEnumerable<int> idsUserGame);
        Task Update(IEnumerable<GameLent> gamesLent);
    }
}
