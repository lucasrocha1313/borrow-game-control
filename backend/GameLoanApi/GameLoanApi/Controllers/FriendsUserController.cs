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
    public class FriendsUserController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IFriendUserRepository _friendUserReposistory;
        private readonly IAuthService _authService;

        public FriendsUserController(IFriendUserRepository friendUserReposistory,
            IAuthService authService,
            IMapper mapper)
        {
            _friendUserReposistory = friendUserReposistory;
            _authService = authService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> AddGames(List<FriendToAddDto> frinedsToAdd, int userId)
        {
            if (_authService.IsUnauthorized(User, userId))
                return Unauthorized();

            var friendsUser = _mapper.Map<List<FriendUser>>(frinedsToAdd);

            await _friendUserReposistory.Add(friendsUser);

            return Ok();
        }
    }
}
