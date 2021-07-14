using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Films.BLL.Models
{
    public class FilmActorDto
    {
        [Key]
        public int Id { get; set; }

        public int FilmId { get; set; }

        public int ActorId { get; set; }
        public string ActorName { get; set; }
    }
}
