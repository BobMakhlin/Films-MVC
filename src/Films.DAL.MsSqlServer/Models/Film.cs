using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Films.DAL.MsSqlServer.Models
{
    public partial class Film
    {
        public Film()
        {
            FilmActor = new HashSet<FilmActor>();
            FilmGenre = new HashSet<FilmGenre>();
            Photo = new HashSet<Photo>();
            Rating = new HashSet<Rating>();
        }

        [Key]
        public int FilmId { get; set; }
        [Column(TypeName = "date")]
        public DateTime FilmDate { get; set; }
        [Required]
        [StringLength(64)]
        public string FilmName { get; set; }
        [Required]
        [StringLength(128)]
        public string FilmDescription { get; set; }

        [InverseProperty("Film")]
        public virtual ICollection<FilmActor> FilmActor { get; set; }
        [InverseProperty("Film")]
        public virtual ICollection<FilmGenre> FilmGenre { get; set; }
        [InverseProperty("Film")]
        public virtual ICollection<Photo> Photo { get; set; }
        [InverseProperty("Film")]
        public virtual ICollection<Rating> Rating { get; set; }
    }
}
