using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Exceptions;
using Catalog.InputModel;
using Catalog.Services;
using Catalog.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GamesCatalogController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GamesCatalogController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameViewModel>>> GetAll()
        {
            var result = await _gameService.Get();

            if (result.Count() == 0)
                return NoContent();

            return Ok(result);
        }

        [HttpGet("{idGame:guid}")]
        public async Task<ActionResult<GameViewModel>> GetbyId([FromRoute] Guid idGame)
        {
            var result = await _gameService.Get(idGame);

            if (result == null)
                return NoContent();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<GameViewModel>> SaveGame([FromBody] GameInputModel game)
        {
            try
            {
                var newGame = await _gameService.Post(game);

                return Ok(newGame);
            }
            catch (GameAlreadyExistsException)
            {

                return UnprocessableEntity("Game already exists on catalog");
            }
        }

        [HttpPut("{idGame:guid}")]
        public async Task<ActionResult> UpdateGame([FromRoute] Guid idGame, [FromBody] GameInputModel game)
        {
            try
            {
                await _gameService.Update(idGame, game);

                return Ok();
            }
            catch (GameNotFoundException)
            {

                return NotFound("Game not found on catalog");
            }
        }

        [HttpPatch("{idGame:guid}/price/{price:double}")]
        public async Task<ActionResult> UpdateGame([FromRoute] Guid idGame, [FromRoute] double price)
        {
            try
            {
                await _gameService.Update(idGame, price);

                return Ok();
            }
            catch (GameNotFoundException)
            {

                return NotFound("Game not found on catalog.");
            }
        }

        [HttpDelete("{idGame:guid}")]
        public async Task<ActionResult> DeleteGame([FromRoute] Guid idGame)
        {
            try
            {
                await _gameService.Delete(idGame);

                return Ok();
            }
            catch (GameNotFoundException)
            {

                return NotFound("Game not found on catalog.");
            }
        }
    }
}
