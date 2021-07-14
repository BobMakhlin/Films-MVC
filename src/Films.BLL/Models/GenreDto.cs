using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Films.BLL.Models
{
    public class GenreDto
    {
        [Key]
        public int GenreId { get; set; }
        [Required]
        [StringLength(48)]
        public string GenreName { get; set; }
    }
}
