using AutoMapper;
using GameLoanApi.Dtos;
using GameLoanApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLoanApi.Mapping
{
    public class AutoMapping: Profile
    {
        public AutoMapping()
        {
            CreateMap<UserForRegisterDto, User>();
            CreateMap<User, UserLoggedDto>();
        }
    }
}
