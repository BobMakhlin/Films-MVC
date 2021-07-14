using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Films.DAL.MsSqlServer.Models
{
    public partial class Photo
    {
        [Key]
        public int PhotoId { get; set; }
        public int FilmId { get; set; }
        [Required]
        [StringLength(64)]
        public string PhotoPath { get; set; }

        [ForeignKey(nameof(FilmId))]
        [InverseProperty("Photo")]
        public virtual Film Film { get; set; }
    }
}
