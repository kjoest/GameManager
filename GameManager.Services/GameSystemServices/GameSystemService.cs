using GameManager.Data;
using GameManager.Models.GameSystemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.Services.GameSystemServices
{
    public class GameSystemService
    {
        public bool CreateGameSystem(GameSystemCreate gameSystemModel)
        {
            var entity =
                new GameSystem()
                {
                    Id = gameSystemModel.Id,
                    Name = gameSystemModel.Name,
                    YearOfRelease = DateTime.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.GameSystems.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GameSystemListDetail> GetGameSystem()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .GameSystems
                    .Select(
                        g =>
                            new GameSystemListDetail
                            {
                                Id = g.Id,
                                Name = g.Name,
                                YearOfRelease = g.YearOfRelease
                            });

                return query.ToArray();
            }
        }

        public GameSystemDetail GetGameSystemById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GameSystems
                        .Single(g => g.Id == id);
                return
                    new GameSystemDetail
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        YearOfRelease = entity.YearOfRelease
                    };
            }
        }

        public bool UpdateGameSystem(GameSystemEdit gameSystemModel)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GameSystems
                        .Single(g => g.Id == gameSystemModel.Id);

                entity.Id = gameSystemModel.Id;
                entity.Name = gameSystemModel.Name;
                entity.YearOfRelease = gameSystemModel.YearOfRelease;

                return ctx.SaveChanges() > 0;
            }
        }

        public bool DeleteGameSystem(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GameSystems
                        .SingleOrDefault(g => g.Id == id);

                ctx.GameSystems.Remove(entity);

                return ctx.SaveChanges() > 0;
            }
        }
    }
}
