using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.Data
{
    public class Game
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime YearOfRelease { get; set; }

        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }
        public virtual Genre Genre {get; set;}

        public bool IfPlayed { get; set; }

        public Rating Rating { get; set; }

        [ForeignKey(nameof(GameSystem))]
        public int GameSystemId { get; set; }
        public virtual GameSystem GameSystem { get; set; }
    }

    public enum Rating
    {
        E = 1,
        E10 = 2,
        T,
        M
    }

    //public enum Genre
    //{
    //    Action = 1,
    //    RPG = 2,
    //    Platformer,
    //    FirstPersonShooter,
    //    Strategy,
    //    Adventure,
    //    Horror,
    //    Sports,
    //    Sandbox
    //}

    //public enum GameSystem
    //{
    //    PS5 = 1,
    //    PS4 = 2,
    //    PS2,
    //    PS1,
    //    XboxSeriesX,
    //    XboxOne,
    //    Xbox360,
    //    Xbox,
    //    PC,
    //    Switch,
    //    WiiU,
    //    Wii,
    //    GameCube,
    //    Nintedo64,
    //    SuperNintendo,
    //    NES,
    //    Nintendo3DS,
    //    DS,
    //    GameboyAdvance,
    //    GameboyColor,
    //    Gameboy
    //}


}
