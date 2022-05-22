using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeliculasCore.Helpers;
using PeliculasCore.Models.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.DTOs.Movies
{
    public class MovieCreationDto : MoviePatchDto
    {  
        [FileSizeValidation(maxSizeInMb: 4)]
        [FileTypeValidation(FileType.Image)]
        public IFormFile? Poster { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int>? GeneroIds { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<ActorMovieCreationDto>>))]
        public List<ActorMovieCreationDto>? Actors { get; set; }
    }
}
