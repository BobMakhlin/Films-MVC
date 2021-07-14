using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Films.DAL.MsSqlServer.Models
{
    public partial class Rating
    {
        [Key]
        public int RatingId { get; set; }
        [Required]
        [StringLength(64)]
        public string UserEmail { get; set; }
        public int FilmId { get; set; }

        [ForeignKey(nameof(FilmId))]
        [InverseProperty("Rating")]
        public virtual Film Film { get; set; }
    }
}
