using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.Models
{
    public class Movie : IEntityId
    {
        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Title { get; set; }

        public bool OnScreen { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string? Poster { get; set; }

        public virtual List<MovieGeneroAssoc>? MovieGeneroAssocs { get; set; }

        public virtual List<MovieActorAssoc>? MovieActorAssocs { get; set; }
    }
}
