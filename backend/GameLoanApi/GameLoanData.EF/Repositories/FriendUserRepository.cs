using GameLoanApi.Data.Repositories;
using GameLoanData.EF.Context;
using GameLoanDomain.Entities;
using GameLoanDomain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameLoanData.EF.Repositories
{
    public class FriendUserRepository : BaseRepository, IFriendUserRepository
    {
        public FriendUserRepository(DataContext context) : base(context) { }
        public async Task Add(List<FriendUser> friends)
        {
            await _context.FriendUser.AddRangeAsync(friends);

            await _context.SaveChangesAsync();
        }
    }
}
