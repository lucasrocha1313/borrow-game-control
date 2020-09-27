using AutoMapper;
using GameLoanApi.Data.Repositories.Interfaces;
using GameLoanApi.Dtos;
using GameLoanApi.Entities;
using GameLoanApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GameLoanApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public AuthController(IAuthService authService,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _authService = authService;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto user)
        {
            user.Username = user.Username.ToLower();

            if (await _userRepository.UserExists(user.Username))
            {
                return BadRequest("Username already Exists!");
            }

            var userToCreate = _mapper.Map<User>(user);

            var createdUser = await _authService.Register(userToCreate, user.Password);

            return Ok(createdUser.Username);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLogin)
        {
            var userFromRepository = await _authService.Login(userForLogin.Username.ToLower(), userForLogin.Password);

            if (userFromRepository == null)
            {
                return Unauthorized();
            }

            return Ok(_authService.GenerateToken(userFromRepository));
        }
    }
}
