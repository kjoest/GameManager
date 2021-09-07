using GameManager.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.Models
{
    public class GameEdit
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime YearOfRelease { get; set; }

        public Genre Genre { get; set; }

        public bool IfPlayed { get; set; }
        public Rating Rating { get; set; }

        public GameSystem GameSystem { get; set; }
    }
}
