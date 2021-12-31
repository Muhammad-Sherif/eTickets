using eTickets.Data.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services.Implementation
{
	public class FileServices : IFileServices
	{
		public byte[] ConvertToByteArray(IFormFile file)
		{
			using var dataStream = new MemoryStream();
			file.CopyTo(dataStream);
			return dataStream.ToArray();

		}
	}
}
