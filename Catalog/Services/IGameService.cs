using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.InputModel;
using Catalog.ViewModel;

namespace Catalog.Services
{
    public interface IGameService : IDisposable
    {
        Task<List<GameViewModel>> Get();
        Task<GameViewModel> Get(Guid id);
        Task<GameViewModel> Post(GameInputModel game);
        Task Update(Guid id, GameInputModel game);
        Task Update(Guid id, double price);
        Task Delete(Guid id);
    }
}
