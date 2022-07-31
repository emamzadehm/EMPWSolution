using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace _01_Framework.Application
{
    public class FileExtentionLimitationAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly string[] _fileExtentionLimitation;

        public FileExtentionLimitationAttribute(string[] fileExtentionLimitation)
        {
            _fileExtentionLimitation = fileExtentionLimitation;
        }

        public override bool IsValid(object value)
        {
            var file = value as IFormFile;
            if (file == null) return true;
            var fileExtention = Path.GetExtension(file.FileName);
            return _fileExtentionLimitation.Contains(fileExtention);
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-valext", "true");
            context.Attributes.Add("data-valext-FileExtentionLimitation", ErrorMessage);
        }
    }
}
