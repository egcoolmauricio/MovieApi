using Microsoft.AspNetCore.Mvc;
using PeliculasCore.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.DTOs.Movie
{
    public class MoviePatchDto
    {
        [Required]
        [StringLength(300)]
        public string Title { get; set; }

        public bool OnScreen { get; set; }

        public DateTime ReleaseDate { get; set; }

       


    }
}
