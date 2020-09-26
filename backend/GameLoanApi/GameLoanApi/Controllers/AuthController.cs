using AutoMapper;
using GameLoanApi.Dtos;
using GameLoanApi.Entities;
using GameLoanApi.Services;
using GameLoanApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLoanApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto user)
        {
            user.Username = user.Username.ToLower();

            //if (await _authService.UserExists(user.Name))
            //{
            //    return BadRequest("Username already Exists!");
            //}

            var userToCreate = _mapper.Map<User>(user);

            var createdUser = await _authService.Register(userToCreate, user.Password);

            //var userToReturn = _mapper.Map<UserForDetailedDto>(createdUser);

            return Ok(createdUser);
        }
    }
}
