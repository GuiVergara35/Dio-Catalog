using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Entities;

namespace Catalog.Repository
{
    public interface IGameRepository : IDisposable
    {
        Task<List<Game>> Get();
        Task<Game> Get(Guid id);
        Task<List<Game>> Get(string name, string publisher);
        Task Save(Game game);
        Task<object> Update(Guid id, Game game);
        Task<bool> Delete(Guid id);
    }
}
