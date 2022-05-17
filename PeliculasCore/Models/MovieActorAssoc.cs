using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.Models
{
    [Table("movie_actor_assoc")]
    public class MovieActorAssoc
    {
        [Column("actor_id")]
        public int ActorId { get; set; }
        public Actor Actor { get; set; }

        [Column("movie_id")]
        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        [StringLength(100)]
        [Required]
        public string Character { get; set; }

        public int Order { get; set; }
    }
}
