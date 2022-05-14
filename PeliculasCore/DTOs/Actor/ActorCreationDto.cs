using Microsoft.AspNetCore.Http;
using PeliculasCore.Models.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.DTOs.Actor
{
    public class ActorCreationDto
    {
        [Required]
        [StringLength(120)]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        [FileSizeValidation(maxSizeInMb:4)]
        [FileTypeValidation(FileType.Image)]
        public IFormFile Photo { get; set; }
    }
}
