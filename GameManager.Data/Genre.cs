using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.Data
{
    public class Genre
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string GenreType { get; set; }
        public string Description { get; set; }
        public virtual List<Game> Games { get; set; }
    }
}
