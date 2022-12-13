using System;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestProject.Interfaces;
using TestProject.Models;
using TestProject.Mvc.Controller;
using TestProject.ViewModels;

namespace TestProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DocumentsController : BaseController<DocumentEntity, IRepo<DocumentEntity>, DocumentViewModel>
    {
        public DocumentsController(
            IRepo<DocumentEntity> repo,
            IMapper mapper,
            ILoggerFactory loggerFactory) : base(repo, mapper, loggerFactory)
        {
        }
    }
}

