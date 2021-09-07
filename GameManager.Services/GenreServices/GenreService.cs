using GameManager.Data;
using GameManager.Models.GenreModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.Services.GenreServices
{
    public class GenreService
    {
        public async Task<bool> CreateGenre(GenreCreate genre)
        {
            var entity = new Genre
            { 
                GenreType = genre.GenreType,
                Description = genre.Description
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Genres.Add(entity);
                return await ctx.SaveChangesAsync() > 0;
            }
        }

        public async Task<IEnumerable<GenreListDetail>> Get()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    await
                    ctx
                    .Genres
                    .Select(g => new GenreListDetail
                    {
                        Id = g.Id,
                        GenreType = g.GenreType,
                    }).ToListAsync();

                return query;
            }
        }

        public async Task<GenreDetail> Get(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var genre =
                    await
                    ctx
                    .Genres
                    .SingleOrDefaultAsync(g => g.Id == id);
                if(genre is null)
                {
                    return null;
                }

                return new GenreDetail
                {
                    Id = genre.Id,
                    GenreType = genre.GenreType,
                    Description = genre.Description
                };
            }
        }
        
        public async Task<bool> Update(GenreEdit genre, int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldGenreData = await ctx.Genres.FindAsync(id);
                if(oldGenreData is null)
                {
                    return false;
                }
                oldGenreData.Id = genre.Id;
                oldGenreData.GenreType = genre.GenreType;
                oldGenreData.Description = genre.Description;

                return await ctx.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var oldGenreData = await ctx.Genres.FindAsync(id);
                if (oldGenreData is null)
                {
                    return false;
                }

                ctx.Genres.Remove(oldGenreData);
                return await ctx.SaveChangesAsync() > 0;
            }
        }
    }
}
