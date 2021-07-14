using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Films.BLL.Models
{
    public class PhotoDto
    {
        [Key]
        public int PhotoId { get; set; }
        public int FilmId { get; set; }
        [Required]
        [StringLength(64)]
        public string PhotoPath { get; set; }
    }
}
