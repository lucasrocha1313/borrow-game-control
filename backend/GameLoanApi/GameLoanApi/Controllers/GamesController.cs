using AutoMapper;
using GameLoanDomain.Dtos;
using GameLoanDomain.Entities;
using GameLoanDomain.Repositories;
using GameLoanDomain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameLoanApi.Controllers
{
    [Route("{userId}/[controller]")]
    [ApiController]
    [Authorize]
    public class GamesController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IGameReposistory _gameReposistory;
        private readonly IAuthService _authService;

        public GamesController(IGameReposistory gameReposistory,
            IAuthService authService,
            IMapper mapper)
        {
            _gameReposistory = gameReposistory;
            _authService = authService;

            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> AddGames(List<GameToAddDto> gamesToAdd, int userId)
        {
            if (_authService.IsUnauthorized(User, userId))
                return Unauthorized();

            var games = _mapper.Map<List<GameUser>>(gamesToAdd);

            await _gameReposistory.Add(games);

            return Ok();
        }
    }
}
