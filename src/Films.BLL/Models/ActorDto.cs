using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Films.BLL.Models
{
    public class ActorDto
    {
        [Key]
        public int ActorId { get; set; }

        [Required]
        [StringLength(64)]
        public string ActorName { get; set; }

        [Column(TypeName = "date")]
        public DateTime ActorBirthday { get; set; }
    }
}
