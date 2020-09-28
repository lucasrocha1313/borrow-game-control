using AutoMapper;
using GameLoanApi.Data.Repositories.Interfaces;
using GameLoanApi.Entities;
using GameLoanApi.Services;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
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

            GenerateMocksWithoutReturn();
            GenerateMocksWithReturn();            
        }

        private void GenerateMocksWithoutReturn()
        {
            _authRepository
                .When(a => a.Register(default)).Do(x => Console.WriteLine("User Registered With success!!"));
        }

        private void GenerateMocksWithReturn()
        {
            _authRepository.GetUserByUsername("Test").ReturnsNull();
        }

        #region Register tests
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

        [Fact]
        public async Task RegisterMinValueDateCreatedNotAllowed()
        {
            var password = "test";
            var user = new User
            {
                Username = "tester",
            };

            var userReturned = await _authService.Register(user, password);

            Assert.Null(userReturned);
        }

        [Fact]
        public async Task RegisterValidUserAllowed()
        {
            var password = "test";
            var user = new User
            {
                Username = "tester",
                Created = DateTime.Now
            };

            var userReturned = await _authService.Register(user, password);

            Assert.NotNull(userReturned);
        }
        #endregion
        #region Login Tests
        [Fact]
        public async Task LoginUserNotFoundUnauthorized()
        {
            var username = "Test";
            var password = "test";

            var userReturned = await _authService.Login(username, password);

            Assert.Null(userReturned);
        }

        [Fact]
        public async Task LoginUserWrongPasswordUnauthorized()
        {
            var username = "Tester";
            var passwordWrong = "test";
            var passwordCorrect = "tester";
            _authService.CreatePasswordHash(passwordCorrect, out byte[] passwordHash, out byte[] passwordSalt);
            _authRepository.GetUserByUsername("Tester").Returns(new User
            {
                Username = "Tester",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            });

            var userReturned = await _authService.Login(username, passwordWrong);

            Assert.Null(userReturned);
        }

        [Fact]
        public async Task LoginUserCorrectPasswordAuthorized()
        {
            var username = "Tester";
            var passwordCorrect = "tester";
            _authService.CreatePasswordHash(passwordCorrect, out byte[] passwordHash, out byte[] passwordSalt);
            _authRepository.GetUserByUsername("Tester").Returns(new User
            {
                Username = "Tester",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            });

            var userReturned = await _authService.Login(username, passwordCorrect);

            Assert.NotNull(userReturned);
        }
        #endregion
    }
}
