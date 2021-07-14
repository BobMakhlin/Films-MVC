using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Films.DAL.MsSqlServer.Models
{
    public partial class FilmGenre
    {
        [Key]
        public int Id { get; set; }
        public int GenreId { get; set; }
        public int FilmId { get; set; }

        [ForeignKey(nameof(FilmId))]
        [InverseProperty("FilmGenre")]
        public virtual Film Film { get; set; }
        [ForeignKey(nameof(GenreId))]
        [InverseProperty("FilmGenre")]
        public virtual Genre Genre { get; set; }
    }
}
