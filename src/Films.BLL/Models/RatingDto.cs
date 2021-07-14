using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Films.BLL.Models
{
    public class RatingDto
    {
        [Key]
        public int RatingId { get; set; }
        [Required]
        [StringLength(64)]
        public string UserEmail { get; set; }
        public int FilmId { get; set; }
    }
}
