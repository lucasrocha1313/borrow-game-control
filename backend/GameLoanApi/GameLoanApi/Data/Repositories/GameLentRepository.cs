﻿using GameLoanApi.Data.Repositories.Interfaces;
using GameLoanApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLoanApi.Data.Repositories
{
    public class GameLentRepository: BaseRepository, IGameLentRepository
    {
        public GameLentRepository(DataContext context) : base(context) { }

        public async Task LendGames(List<GameLent> gameToLent)
        {
            await _context.GameLent.AddRangeAsync(gameToLent);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<GameLent> GetLentGamesByUserGameId(IEnumerable<int> idsUserGame)
        {
            return _context.GameLent.Where(gl => gl.ReturnDate == null && idsUserGame.Contains(gl.IdGame));
        }

        public async Task Update(IEnumerable<GameLent> gamesLent)
        {
            _context.GameLent.UpdateRange(gamesLent);

            await _context.SaveChangesAsync();
        }
    }
}
