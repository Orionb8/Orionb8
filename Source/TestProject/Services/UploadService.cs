using System;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using TestProject.Models;
using TestProject.Data.Context;
using Microsoft.AspNetCore.Hosting;

namespace TestProject.Services
{
    public class UploadService : IUploadService
    {
        private readonly DatabaseContext _ctx;
        private readonly IWebHostEnvironment _env;

        public UploadService(DatabaseContext ctx, IWebHostEnvironment env)
        {
            _ctx = ctx;
            _env = env;
        }

        public async Task<UploadEntity> Upload(IFormFile file)
        {
            string guid = Guid.NewGuid().ToString();

            string extension = Path.GetExtension(file.FileName).Substring(1);
            string directoryPath = Path.Combine(_env.WebRootPath, "PDFs");

            string newFileName = string.Format("{0}.{1}", guid, extension);
            string filePath = Path.Combine(directoryPath, newFileName);

            using (var stream = new FileStream(filePath, FileMode.CreateNew, FileAccess.ReadWrite))
            {

                await file.CopyToAsync(stream);
                var upload = new UploadEntity();

                upload.FileName = newFileName;
                upload.FileScreenName = file.FileName;
                upload.FilePath = string.Format("/PDFs/{0}", newFileName);
                // upload.Created = DateTime.Now;
                upload.FileSize = file.Length;
                upload.Code = guid;
                upload.downloadUrl = "http://localhost:5006" + upload.FilePath;

                _ctx.Uploads.Add(upload);
                await _ctx.SaveChangesAsync();

                return upload;
            }

            return null;
        }


    }
}

