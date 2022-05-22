using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.DTOs.Movies
{
    public class MovieIndexDto
    {
        public List<MovieDto> ComingSoon { get; set; }
        public List<MovieDto> OnScreen { get; set; }
    }
}
