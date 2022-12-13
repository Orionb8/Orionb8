using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class EmployeesController : BaseController<EmployeeEntity, IRepo<EmployeeEntity>, EmployeeViewModel>
    {
        private readonly IRepo<ProjectEntity> _projectRepo;
        public EmployeesController(
            IRepo<EmployeeEntity> repo,
            IRepo<ProjectEntity> projectRepo,
            IMapper mapper,
            ILoggerFactory loggerFactory) : base(repo, mapper, loggerFactory)
        {
            _projectRepo = projectRepo;
        }


        [HttpGet("filterByTeam/{id}")]
        public async Task<IActionResult> FilterByTeam([FromRoute] int id)
        {
            var project = await _projectRepo.Set().FirstOrDefaultAsync(x => x.Id == id);
            var employees = _repo.Set().Where(x => x.TeamId == project.TeamId);
            return Ok(new
            {
                data = await employees.ProjectTo<EmployeeViewModel>(_mapper.ConfigurationProvider).ToListAsync(),
                count = await employees.CountAsync()
            });
        }
    }
}

