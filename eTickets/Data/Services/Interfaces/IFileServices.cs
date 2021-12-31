using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services.Interfaces
{
	public interface IFileServices
	{
		byte[] ConvertToByteArray(IFormFile file);
	}
}
