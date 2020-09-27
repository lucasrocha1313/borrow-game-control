using GameLoanApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLoanApi.Data.Repositories.Interfaces
{
    public interface IFriendUserRepository
    {
        Task Add(List<FriendUser> friends);
    }
}
