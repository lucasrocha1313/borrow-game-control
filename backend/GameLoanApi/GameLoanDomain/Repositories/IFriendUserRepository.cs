using GameLoanDomain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameLoanDomain.Repositories
{
    public interface IFriendUserRepository
    {
        Task Add(List<FriendUser> friends);
    }
}
