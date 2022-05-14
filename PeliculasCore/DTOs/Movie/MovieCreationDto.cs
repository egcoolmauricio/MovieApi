using Microsoft.AspNetCore.Http;
using PeliculasCore.Models.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.DTOs.Movie
{
    public class MovieCreationDto : MoviePatchDto
    {  
        [FileSizeValidation(maxSizeInMb: 4)]
        [FileTypeValidation(FileType.Image)]
        public IFormFile Poster { get; set; }
    }
}
