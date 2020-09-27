using GameLoanApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameLoanApi.Data.Repositories.Interfaces
{
    public interface IGameLentRepository
    {
        Task LendGames(List<GameLent> gameToLent);
        IEnumerable<GameLent> GetLentGamesByUserGameId(IEnumerable<int> idsUserGame);
    }
}
