using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.DTOs.Movie
{
    public class MovieDto
    {
        public int Id { get; set; }
       
        public string Title { get; set; }

        public bool OnScreen { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string? Poster { get; set; }
    }
}
