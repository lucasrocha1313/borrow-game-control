using GameLoanApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLoanApi.Services.Interfaces
{
    public interface IGameLoanService
    {
        bool GameAlreadyLent(IEnumerable<int> idsUserGame);
        Task LentGames(List<GameToLentDto> gameToLent, int idFriend);
    }
}
