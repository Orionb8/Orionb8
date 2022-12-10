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
    public class TeamsController : BaseController<TeamEntity, IRepo<TeamEntity>, TeamViewModel>
    {
        public TeamsController(
            IRepo<TeamEntity> repo,
            IMapper mapper,
            ILoggerFactory loggerFactory) : base(repo, mapper, loggerFactory)
        {
        }
    }
}

