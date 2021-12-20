using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.CustomDataAnnotation
{
	public class MaxFileSizeAttribute : ValidationAttribute
	{
		private readonly long _maxSizeInMegaBytes;
		private readonly long _maxSizeInBytes;
		public MaxFileSizeAttribute(long maxSizeInMegaBytes)
		{
			_maxSizeInMegaBytes = maxSizeInMegaBytes;
			_maxSizeInBytes = maxSizeInMegaBytes * 1000000;
		}

		public override string FormatErrorMessage(string name)
		{
			return ErrorMessage == null ? $"File size must be not greater than {_maxSizeInMegaBytes} mega bytes" : ErrorMessage;
		}
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var file = value as IFormFile;
			if (value is null)
				return ValidationResult.Success;

			return file.Length > _maxSizeInBytes ? new ValidationResult(null) : ValidationResult.Success;

		}

	}
}
