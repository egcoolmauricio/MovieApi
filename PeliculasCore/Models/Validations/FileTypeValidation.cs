using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeliculasCore.Models.Validations
{
    public class FileTypeValidation : ValidationAttribute
    {
        private readonly string[] validTypes;
        private readonly FileType fileType;

        public FileTypeValidation(string[] validTypes)
        {
            this.validTypes = validTypes;
        }

        public FileTypeValidation(FileType fileType)
        {
            if(fileType == FileType.Image)
            {
                validTypes = new string[] { "image/jpeg", "image/png", "image/gif" };
            }            
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            IFormFile formFile = value as IFormFile;
            if (formFile == null)
            {
                return ValidationResult.Success;
            }

            if (!validTypes.Contains(formFile.ContentType))
            {
                return new ValidationResult($"file type must be: {string.Join(", ", fileType)}");
            }
            return ValidationResult.Success;
        }


    }

    public enum FileType
    {
        Image
    }

}
