using AutoMapper;
using GameLoanApi.Data.Repositories.Interfaces;
using GameLoanApi.Dtos;
using GameLoanApi.Entities;
using GameLoanApi.Exceptions;
using GameLoanApi.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GameLoanApi.Services
{
    public class AuthService: IAuthService
    {
        private readonly IMapper _mapper;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _config;

        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository,
            Microsoft.Extensions.Configuration.IConfiguration config,
            IMapper mapper)
        {
            _authRepository = authRepository;
            _config = config;
            _mapper = mapper;
        }

        public async Task<User> Login(string userName, string password)
        {
            try
            {
                var userDb = await _authRepository.GetUserByUsername(userName);

                if (userDb == null)
                    return null;

                if (!VerifyPasswordHash(password, userDb.PasswordHash, userDb.PasswordSalt))
                    return null;

                return userDb;
            }
            catch(Exception ex)
            {
                throw new LoginException(ex.Message);
            }
            
        }

        public async Task<User> Register(User user, string password)
        {
            try
            {
                if(IsValidToRegister(user, password))
                {
                    CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;

                    await _authRepository.Register(user);

                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error Registering User" + ex.Message);
                throw new RegisterUserException(ex.Message);
            }
            
        }

        public object GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
                    .GetBytes(_config["AppSettings:Token"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var userLogged = _mapper.Map<UserLoggedDto>(user);

            return new
            {
                token = tokenHandler.WriteToken(token),
                userLogged
            };
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                return computedHash.SequenceEqual(passwordHash);
            }
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        private bool IsValidToRegister(User user, string password)
        {
            if (string.IsNullOrEmpty(password))
                return false;

            return user.Valid();
        }
    }
}
