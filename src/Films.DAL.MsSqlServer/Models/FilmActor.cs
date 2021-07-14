using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Films.DAL.MsSqlServer.Models
{
    public partial class FilmActor
    {
        [Key]
        public int Id { get; set; }
        public int FilmId { get; set; }
        public int ActorId { get; set; }

        [ForeignKey(nameof(ActorId))]
        [InverseProperty("FilmActor")]
        public virtual Actor Actor { get; set; }
        [ForeignKey(nameof(FilmId))]
        [InverseProperty("FilmActor")]
        public virtual Film Film { get; set; }
    }
}
