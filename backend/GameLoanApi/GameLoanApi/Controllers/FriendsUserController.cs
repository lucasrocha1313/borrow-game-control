using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameLoanApi.Data.Repositories.Interfaces;
using GameLoanApi.Dtos;
using GameLoanApi.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameLoanApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class FriendsUserController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IFriendUserRepository _friendUserReposistory;

        public FriendsUserController(IFriendUserRepository friendUserReposistory, IMapper mapper)
        {
            _friendUserReposistory = friendUserReposistory;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> AddGames(List<FriendToAddDto> frinedsToAdd)
        {
            var friendsUser = _mapper.Map<List<FriendUser>>(frinedsToAdd);

            await _friendUserReposistory.Add(friendsUser);

            return Ok();
        }
    }
}
