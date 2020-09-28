using GameLoanApi.Data.Repositories;
using GameLoanData.EF.Context;
using GameLoanDomain.Entities;
using GameLoanDomain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLoanData.EF.Repositories
{
    public class GameRepository : BaseRepository, IGameReposistory
    {
        public GameRepository(DataContext context) : base(context) { }

        public async Task Add(List<GameUser> games)
        {
            await _context.Game.AddRangeAsync(games);

            await _context.SaveChangesAsync();
        }

        public IEnumerable<GameUser> GetByUser(int userId)
        {
            return _context.Game.Where(g => g.IdUser == userId);
        }
    }
}
