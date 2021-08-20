using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Entities;
using Catalog.Exceptions;
using Catalog.InputModel;
using Catalog.Repository;
using Catalog.ViewModel;

namespace Catalog.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<List<GameViewModel>> Get()
        {
            var result = await _gameRepository.Get();

            return result.Select(game => new GameViewModel
            {
                Id = game.Id,
                Name = game.Name,
                Publisher = game.Publisher,
                Price = game.Price
            }).ToList();
        }

        public async Task<GameViewModel> Get(Guid id)
        {
            var result = await _gameRepository.Get(id);

            if (result == null)
                return null;

            return new GameViewModel
            {
                Id = result.Id,
                Name = result.Name,
                Publisher = result.Publisher,
                Price = result.Price
            };
        }

        public async Task<GameViewModel> Post(GameInputModel game)
        {
            var gameEntity = await _gameRepository.Get(game.Name, game.Publisher);

            if (gameEntity.Count() > 0)
                throw new GameAlreadyExistsException();

            var gameInsert = new Game
            {
                Id = Guid.NewGuid(),
                Name = game.Name,
                Publisher = game.Publisher,
                Price = game.Price
            };

            await _gameRepository.Save(gameInsert);

            return new GameViewModel
            {
                Id = gameInsert.Id,
                Name = game.Name,
                Publisher = game.Publisher,
                Price = game.Price
            };
        }

        public async Task Update(Guid id, GameInputModel game)
        {
            var gameEntity = await _gameRepository.Get(id);

            if (gameEntity == null)
                throw new GameNotFoundException();

            gameEntity.Name = game.Name;
            gameEntity.Publisher = game.Publisher;
            gameEntity.Price = game.Price;

            await _gameRepository.Update(id, gameEntity);
        }

        public async Task Update(Guid id, double price)
        {
            var gameEntity = await _gameRepository.Get(id);

            if (gameEntity == null)
                throw new GameNotFoundException();

            gameEntity.Price = price;

            await _gameRepository.Update(id, gameEntity);
        }

        public async Task Delete(Guid id)
        {
            var gameEntity = await _gameRepository.Get(id);

            if (gameEntity == null)
                throw new GameNotFoundException();

            await _gameRepository.Delete(id);
        }

        public void Dispose()
        {
            _gameRepository?.Dispose();
        }
    }


}
