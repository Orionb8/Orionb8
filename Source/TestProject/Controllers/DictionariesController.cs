using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestProject.Interfaces;
using TestProject.Models.Dictionaries;
using TestProject.ViewModels;

namespace TestProject.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DictionariesController : ControllerBase
    {
        private readonly IHRepo<HPositionEntity> _positionService;
        private readonly IMapper _mapper;
        private readonly IHRepo<HProjectTypeEntity> _projectTypeService;
        private readonly IHRepo<HProjectStatusEntity> _projectStatusService;
        private readonly IHRepo<HProjectDesicionEntity> _projectDesicionService;
        private readonly ILogger _logger;

        public DictionariesController(
            IHRepo<HPositionEntity> positionService,
            IHRepo<HProjectTypeEntity> projectTypeService,
            IHRepo<HProjectStatusEntity> projectStatusService,
            IHRepo<HProjectDesicionEntity> projectDesicionService,
            IMapper mapper,
            ILoggerFactory loggerFactory
            )
        {
            _positionService = positionService;
            _projectTypeService = projectTypeService;
            _projectStatusService = projectStatusService;
            _projectDesicionService = projectDesicionService;
            _mapper = mapper;
            _logger = loggerFactory.CreateLogger(GetType());

        }

        [HttpGet]
        public IActionResult Positions()
        {
            try
            {                
                var data = _mapper.Map<List<HPositionViewModel>>(_positionService.Set());
                return Ok(data);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error while fetching Positions {exception.Message}");
                throw exception;
            }
        }

        [HttpGet]
        public IActionResult ProjectTypes()
        {
            try
            {
                var data = _mapper.Map<List<HProjectTypeViewModel>>(_projectTypeService.Set());
                return Ok(data);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error while fetching Project Typrs {exception.Message}");
                throw exception;
            }
        }

        [HttpGet]
        public IActionResult ProjectStatuses()
        {
            try
            {
                var data = _mapper.Map<List<HProjectStatusViewModel>>(_projectStatusService.Set());
                return Ok(data);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error while fetching Project Statuses {exception.Message}");
                throw exception;
            }
        }

        [HttpGet]
        public IActionResult ProjectDesicions()
        {
            try
            {
                var data = _mapper.Map<List<HProjectDesicionViewModel>>(_projectDesicionService.Set());
                return Ok(data);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error while fetching Project Desicions {exception.Message}");
                throw exception;
            }
        }
    }
}

