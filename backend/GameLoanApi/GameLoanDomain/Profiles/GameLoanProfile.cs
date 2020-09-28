using AutoMapper;
using GameLoanDomain.Dtos;
using GameLoanDomain.Entities;

namespace GameLoanApi.Mapping
{
    public class GameLoanProfile : Profile
    {
        public GameLoanProfile()
        {
            CreateMap<UserForRegisterDto, User>();
            CreateMap<User, UserLoggedDto>();
            CreateMap<GameToAddDto, GameUser>();
            CreateMap<FriendToAddDto, FriendUser>();
            CreateMap<GameToLentDto, GameLent>();
        }
    }
}
