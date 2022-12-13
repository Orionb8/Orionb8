using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestProject.Services;

namespace TestProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UploadController : ControllerBase
    {
        private readonly IUploadService _service;
        private readonly IMapper _mapper;

        public UploadController(IUploadService service, IMapper mapper)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] UploadDTO dTO)
        {
            var upload = await _service.Upload(dTO.File);

            return Ok(upload);
        }
    }

    public class UploadDTO
    {
        public IFormFile File { get; set; }
    }
}

