using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.Models
{
    public class Genero : IEntityId
    {
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; } = string.Empty;

        public virtual List<MovieGeneroAssoc>? MovieGeneroAssocs { get; set; }
    }
}
