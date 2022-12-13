using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using TestProject.Models;

namespace TestProject.Services
{
	public interface IUploadService
	{
        Task<UploadEntity> Upload(IFormFile file);
    }
}

