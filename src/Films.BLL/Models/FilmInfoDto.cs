using System;
using System.Collections.Generic;
using System.Text;

namespace Films.BLL.Models
{
    public class FilmInfoDto
    {
        public int FilmId { get; set; }
        public string FilmName { get; set; }
        public int FilmYear { get; set; }
        public string FilmDescription { get; set; }

        public IEnumerable<string> Genres { get; set; }
        public IEnumerable<string> Actors { get; set; }
        public IEnumerable<string> Photos { get; set; }
    }
}
