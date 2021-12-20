using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.CustomDataAnnotation
{
	public class AllowedExtensionsAttribute : ValidationAttribute
	{
		private string[] _extentions;
		public AllowedExtensionsAttribute(string[] extentions)
		{
			_extentions = extentions;
		}
		public override string FormatErrorMessage(string name)
		{
			return ErrorMessage == null ? $"Invalid extension" : ErrorMessage;
		}
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var file = value as IFormFile;
			if (file is null)
				return ValidationResult.Success;
			var fileExtention = Path.GetExtension(file.FileName);
			_extentions = _extentions.Select(s => s.ToLower()).ToArray();
			return _extentions.Contains(fileExtention.ToLower()) ? ValidationResult.Success: new ValidationResult(null);

		}
	}
}
