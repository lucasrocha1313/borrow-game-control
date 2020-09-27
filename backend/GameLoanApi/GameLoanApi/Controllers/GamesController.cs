using AutoMapper;
using GameLoanApi.Data.Repositories.Interfaces;
using GameLoanApi.Dtos;
using GameLoanApi.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameLoanApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class GamesController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IGameReposistory _gameReposistory;

        public GamesController(IGameReposistory gameReposistory, IMapper mapper)
        {
            _gameReposistory = gameReposistory;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> AddGames(List<GameToAddDto> gamesToAdd)
        {
            var games = _mapper.Map<List<GameUser>>(gamesToAdd);

            await _gameReposistory.Add(games);

            return Ok();
        }
    }
}
