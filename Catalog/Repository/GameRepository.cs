using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Data;
using Catalog.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Repository
{
    public class GameRepository : IGameRepository
    {

        private readonly ApplicationDbContext _database;

        public GameRepository(ApplicationDbContext database)
        {
            _database = database;
        }

        public async Task<List<Game>> Get()
        {
            var games = await _database.Games.ToListAsync();
            return games;
        }

        public async Task<Game> Get(Guid id)
        {
            var game = await _database.Games.FirstOrDefaultAsync(g => g.Id.Equals(id));
            return game;
        }

        public async Task<List<Game>> Get(string name, string publisher)
        {
            var games = await _database.Games.Where(g => g.Name.Equals(name) && g.Publisher.Equals(publisher)).ToListAsync();
            return games;
        }


        public async Task Save(Game game)
        {
            _database.Games.Add(game);

            await _database.SaveChangesAsync();
        }

        public async Task<object> Update(Guid id, Game game)
        {
            var gameDb = await _database.Games.FirstOrDefaultAsync(g => g.Id.Equals(id));
            if (gameDb == null)
                return null;

            _database.Entry(gameDb).CurrentValues.SetValues(game);
            await _database.SaveChangesAsync();
            return game;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _database.Games.FirstOrDefaultAsync(g => g.Id.Equals(id));
            if (result == null)
                return false;

            _database.Games.Remove(result);
            await _database.SaveChangesAsync();
            return true;
        }

        public void Dispose()
        {
            // throw new NotImplementedException();
        }
    }
}
