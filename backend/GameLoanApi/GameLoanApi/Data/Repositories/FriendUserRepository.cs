using GameLoanApi.Data.Repositories.Interfaces;
using GameLoanApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLoanApi.Data.Repositories
{
    public class FriendUserRepository: BaseRepository, IFriendUserRepository
    {
        public FriendUserRepository(DataContext context) : base(context) { }
        public async Task Add(List<FriendUser> friends)
        {
            await _context.FriendUser.AddRangeAsync(friends);

            await _context.SaveChangesAsync();
        }
    }
}
