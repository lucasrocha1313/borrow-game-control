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
    [Route("{userId}/[controller]")]
    [ApiController]
    [Authorize]
    public class GameLoanController : ControllerBase
    {
        private readonly IGameLoanService _gameLoanService;
        private readonly IAuthService _authService;

        public GameLoanController(IGameLoanService gameLoanService,
            IAuthService authService)
        {
            _gameLoanService = gameLoanService;
            _authService = authService;
        }
        [HttpPost("{idFriend}")]
        public async Task<IActionResult> LentGame(List<GameToLentDto> gameToLent, int userId, int idFriend)
        {
            if (_authService.IsUnauthorized(User, userId))
                return Unauthorized();

            if (_gameLoanService.GameAlreadyLent(gameToLent.Select(g => g.IdGame)))
            {
                return BadRequest("One of the Game(s) already on lent");
            }

            await _gameLoanService.LentGames(gameToLent, idFriend);
            return Ok("Games Loaned!!");
        }

        [HttpPost("return")]
        public async Task<IActionResult> ReturnGames(List<GameReturnedDto> gamesReturned, int userId)
        {
            if (_authService.IsUnauthorized(User, userId))
                return Unauthorized();

            await _gameLoanService.MarkReturnedGames(gamesReturned.Select(g => g.IdGame));

            return Ok("Games Returned!!");
        }
    }
}
