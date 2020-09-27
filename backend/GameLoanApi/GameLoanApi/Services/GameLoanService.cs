using AutoMapper;
using GameLoanApi.Data.Repositories.Interfaces;
using GameLoanApi.Dtos;
using GameLoanApi.Entities;
using GameLoanApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLoanApi.Services
{
    public class GameLoanService: IGameLoanService
    {
        private readonly IMapper _mapper;
        private readonly IGameLentRepository _gameLentRepository;

        public GameLoanService(IGameLentRepository gameLentRepository, IMapper mapper)
        {
            _gameLentRepository = gameLentRepository;
            _mapper = mapper;
        }
        public bool GameAlreadyLent(IEnumerable<int> idsUserGame)
        {
            var gamesLent = _gameLentRepository.GetLentGamesByUserGameId(idsUserGame);

            return gamesLent.Any();
        }

        public async Task LentGames(List<GameToLentDto> gamesToLent, int idFriend)
        {
            var gamesLent = _mapper.Map<List<GameLent>>(gamesToLent);
            foreach(var gameLent in gamesLent)
            {
                gameLent.IdFriend = idFriend;
            }

            await _gameLentRepository.LendGames(gamesLent);
        }

        public async Task MarkReturnedGames(IEnumerable<int> idsGamesUser)
        {
            var gamesLoaned = _gameLentRepository.GetLentGamesByUserGameId(idsGamesUser);
            foreach (var gameLoaned in gamesLoaned)
            {
                gameLoaned.ReturnDate = DateTime.Now;
            }
            await _gameLentRepository.Update(gamesLoaned);
        }
    }
}
