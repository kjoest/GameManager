using GameManager.Models.GameSystemModels;
using GameManager.Services.GameSystemServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GameManager.WebAPI.Controllers.GameSystemControllers
{
    public class GameSystemController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            GameSystemService gameSystemService = CreateGameSystemService();
            var gameSystems = gameSystemService.GetGameSystem();
            return Ok(gameSystems);
        }

        [HttpPost]
        public IHttpActionResult Post(GameSystemCreate gameSystem)
        {
            if (gameSystem == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGameSystemService();

            if (!service.CreateGameSystem(gameSystem))
                return InternalServerError();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            GameSystemService gameSystemService = CreateGameSystemService();
            var gameSystem = gameSystemService.GetGameSystemById(id);
            return Ok(gameSystem);
        }

        [HttpPut]
        public IHttpActionResult Put(GameSystemEdit gameSystem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateGameSystemService();

            if (!service.UpdateGameSystem(gameSystem))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateGameSystemService();

            if (!service.DeleteGameSystem(id))
                return InternalServerError();

            return Ok();
        }

        private GameSystemService CreateGameSystemService()
        {
            var gameSystemService = new GameSystemService();
            return gameSystemService;
        }
    }
}
