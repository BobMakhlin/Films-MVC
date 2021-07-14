using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Films.BLL.Models
{
    public class FilmDto
    {
        [Key]
        public int FilmId { get; set; }

        [Column(TypeName = "date")]
        public DateTime FilmDate { get; set; }

        [Required]
        [StringLength(64)]
        public string FilmName { get; set; }

        [Required]
        [StringLength(256)]
        public string FilmDescription { get; set; }
    }
}
