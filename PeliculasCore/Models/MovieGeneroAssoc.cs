using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.Models
{
    [Table("movie_genero_assoc")]
    public class MovieGeneroAssoc
    {
        [Column("genero_id")]
        public int GeneroId { get; set; }
        public Genero Genero{ get; set; }

        [Column("movie_id")]
        public int MovieId { get; set; }

        public Movie Movie { get; set; }

    }
}
