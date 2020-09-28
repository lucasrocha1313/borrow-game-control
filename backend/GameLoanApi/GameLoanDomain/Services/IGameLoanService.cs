using GameLoanDomain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameLoanDomain.Services
{
    public interface IGameLoanService
    {
        bool GameAlreadyLent(IEnumerable<int> idsUserGame);
        Task LentGames(List<GameToLentDto> gameToLent, int idFriend);
        Task MarkReturnedGames(IEnumerable<int> idsGamesUser);
    }
}
