using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.Models
{
    public class Actor : IEntityId
    {
        public int Id { get; set; }

        [Required]
        [StringLength(120)]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string? Photo { get; set; }

        public virtual List<MovieActorAssoc>? MovieActorAssocs { get; set; }
    }
}
