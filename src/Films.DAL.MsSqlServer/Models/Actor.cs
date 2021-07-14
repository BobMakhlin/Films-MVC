using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Films.DAL.MsSqlServer.Models
{
    public partial class Actor
    {
        public Actor()
        {
            FilmActor = new HashSet<FilmActor>();
        }

        [Key]
        public int ActorId { get; set; }
        [Required]
        [StringLength(64)]
        public string ActorName { get; set; }
        [Column(TypeName = "date")]
        public DateTime ActorBirthday { get; set; }

        [InverseProperty("Actor")]
        public virtual ICollection<FilmActor> FilmActor { get; set; }
    }
}
