using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameLoanApi.Dtos;
using GameLoanApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameLoanApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class GameLoanController : ControllerBase
    {
        private readonly IGameLoanService _gameLoanService;

        public GameLoanController(IGameLoanService gameLoanService)
        {
            _gameLoanService = gameLoanService;
        }
        [HttpPost("{idFriend}")]
        public async Task<IActionResult> LentGame(List<GameToLentDto> gameToLent, int idFriend)
        {            
            if(_gameLoanService.GameAlreadyLent(gameToLent.Select(g => g.IdGame)))
            {
                return BadRequest("One of the Game(s) already on lent");
            }

            await _gameLoanService.LentGames(gameToLent, idFriend);
            return Ok("Games Loaned!!");
        }

        [HttpPost("return")]
        public async Task<IActionResult> ReturnGames(List<GameReturnedDto> gamesReturned)
        {
            await _gameLoanService.MarkReturnedGames(gamesReturned.Select(g => g.IdGame));

            return Ok("Games Returned!!");
        }
    }
}
