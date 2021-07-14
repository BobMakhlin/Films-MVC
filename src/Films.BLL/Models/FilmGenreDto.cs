using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Films.BLL.Models
{
    public class FilmGenreDto
    {
        [Key]
        public int Id { get; set; }

        public int GenreId { get; set; }
        public string GenreName { get; set; }

        public int FilmId { get; set; }
    }
}
