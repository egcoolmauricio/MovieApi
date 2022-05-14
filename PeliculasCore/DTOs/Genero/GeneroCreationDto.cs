﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.DTOs.Genero
{
    public class GeneroCreationDto
    {
        [Required]
        [StringLength(40)]
        public string Name { get; set; } = string.Empty;
    }
}
