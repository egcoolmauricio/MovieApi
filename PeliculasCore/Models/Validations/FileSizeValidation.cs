using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.Models.Validations
{
    public class FileSizeValidation : ValidationAttribute
    {
        private readonly int maxSizeInMb;

        public FileSizeValidation(int maxSizeInMb)
        {
            this.maxSizeInMb = maxSizeInMb;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validation)
        {
            if(value == null)
            {
                return ValidationResult.Success;
            }

            IFormFile formFile = value as IFormFile;
            if(formFile == null)
            {
                return ValidationResult.Success;
            }
            
            if(formFile.Length > maxSizeInMb * 1024 * 1024)
            {
                return new ValidationResult($"Max size cannot be gratter than {maxSizeInMb}Mb");
            }
            return ValidationResult.Success;

        }
    }
}
