using GameManager.Models;
using GameManager.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace GameManager.WebAPI.Controllers.GameControllers
{
    [Authorize]
    public class GameController : ApiController
    {
        // GET: Game
       
        public IHttpActionResult Get()
        {
            GameService gameService = CreateGameService();
            var games = gameService.GetGames();
            return Ok(games);
        }
        public IHttpActionResult Get(int id)
        {
            GameService gameService = CreateGameService();
            var game = gameService.GetGameById(id);
            return Ok(game);
        }
        public IHttpActionResult Post(GameCreate game)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGameService();

            if (!service.CreateGame(game))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Put(GameEdit game)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGameService();
            if (!service.UpdateGame(game))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateGameService();

            if (!service.DeleteGame(id))
                return InternalServerError();

            return Ok();
        }
        private GameService CreateGameService()
        {

            var gameService = new GameService();
            return gameService;
        }
    }
}