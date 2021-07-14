using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Films.DAL.MsSqlServer.Models
{
    public partial class Genre
    {
        public Genre()
        {
            FilmGenre = new HashSet<FilmGenre>();
        }

        [Key]
        public int GenreId { get; set; }
        [Required]
        [StringLength(48)]
        public string GenreName { get; set; }

        [InverseProperty("Genre")]
        public virtual ICollection<FilmGenre> FilmGenre { get; set; }
    }
}
