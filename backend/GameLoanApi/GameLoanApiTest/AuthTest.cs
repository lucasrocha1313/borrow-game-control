using AutoMapper;
using GameLoanApi.Data.Repositories.Interfaces;
using GameLoanApi.Entities;
using GameLoanApi.Services;
using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GameLoanApiTest
{
    public class AuthTest
    {
        private readonly AuthService _authService;
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _config;

        public AuthTest()
        {            
            _authRepository = Substitute.For<IAuthRepository>();

            _authService = new AuthService(_authRepository, _config, _mapper);

            _authRepository
                .When(a => a.Register(default)).Do(x => Console.WriteLine("User Registered With success!!"));
        }


        [Fact]
        public async Task RegisterEmptyPasswordNotAllowed()
        {
            var password = "";
            var user = new User
            {
                Username = "Tester",
                Created = DateTime.Now,

            };

            var userReturned = await _authService.Register(user, password);

            Assert.Null(userReturned);
        }

        [Fact]
        public async Task RegisterEmptyUsernameNotAllowed()
        {
            var password = "test";
            var user = new User
            {
                Username = "",
                Created = DateTime.Now,

            };

            var userReturned = await _authService.Register(user, password);

            Assert.Null(userReturned);
        }
    }
}
