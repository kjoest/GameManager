using GameManager.Models.GenreModels;
using GameManager.Services.GenreServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace GameManager.WebAPI.Controllers.GenreControllers
{
    public class GenreController : ApiController
    {
        private GenreService CreateGenreService()
        {
            var svc = new GenreService();
            return svc;
        }

        public async Task<IHttpActionResult> Post([FromBody] GenreCreate genre)
        {
            if (genre is null || !ModelState.IsValid)
            {
                return (BadRequest(ModelState));
            }
            var svc = CreateGenreService();
            var success = await svc.CreateGenre(genre);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }

        public async Task<IHttpActionResult> Get()
        {
            var svc = CreateGenreService();
            var genres = await svc.Get();
            return Ok(genres);
        }

        public async Task<IHttpActionResult> Get([FromUri] int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            var svc = CreateGenreService();
            var g = await svc.Get(id);
            return Ok(g);
        }

        public async Task<IHttpActionResult> Put([FromBody] GenreEdit genre, [FromUri] int id)
        {
            if (id<1 || id!=genre.Id || genre is null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var svc = CreateGenreService();
            var success = await svc.Update(genre, id);
            if (success)
            {
                return Ok();
            }
            return InternalServerError();
        }

        public async Task<IHttpActionResult> Delete([FromUri] int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            var svc = CreateGenreService();
            var success = svc.Delete(id);
            if (await success)
            {
                return Ok();
            }
            return InternalServerError();
        }
    }
}