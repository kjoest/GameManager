using GameManager.Data;
using GameManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.Services
{
    public class GameService
    {
        public bool CreateGame(GameCreate model)
        {
            var entity =
                new Game()
                {
                    Id = model.Id,
                    Title = model.Title,
                    Description = model.Description,
                    YearOfRelease = model.YearOfRelease,
                    Genre = model.Genre,
                    IfPlayed = model.IfPlayed,
                    Rating = model.Rating,
                    GameSystem = model.GameSystem
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Games.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<GameListDetail> GetGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Games
                        
                        .Select(
                        g =>
                            new GameListDetail
                            {
                                Id = g.Id,
                                Title = g.Title,
                                YearOfRelease = g.YearOfRelease,
                                Genre = g.Genre,
                                IfPlayed = g.IfPlayed,
                                Rating = g.Rating,
                                GameSystem = g.GameSystem
                            }
                                );
                return query.ToArray();
            }
        }
        public GameDetail GetGameById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Games
                    .Single(g => g.Id == id);
                return
                    new GameDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Description = entity.Description,
                        YearOfRelease = entity.YearOfRelease,
                        Genre = entity.Genre,
                        IfPlayed = entity.IfPlayed,
                        Rating = entity.Rating,
                        GameSystem = entity.GameSystem

                    };
            }
        }
        public bool UpdateGame(GameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Games
                    .Single(g => g.Id == model.Id);
                entity.Id = model.Id;
                entity.Title = model.Title;
                entity.Description = model.Description;
                entity.YearOfRelease = model.YearOfRelease;
                entity.Genre = model.Genre;
                entity.IfPlayed = model.IfPlayed;
                entity.Rating = model.Rating;
                entity.GameSystem = model.GameSystem;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteGame(int gameId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Games
                    .Single(g => g.Id == gameId);
                ctx.Games.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
    

