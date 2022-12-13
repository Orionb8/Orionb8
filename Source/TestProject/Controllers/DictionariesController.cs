using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly IHRepo<HTabEntity> _tabService;
        private readonly IHRepo<HFolderEntity> _folderService;
        private readonly IHRepo<HDocumentTypeEntity> _documentTypeService;
        private readonly ILogger _logger;

        public DictionariesController(
            IHRepo<HPositionEntity> positionService,
            IHRepo<HProjectTypeEntity> projectTypeService,
            IHRepo<HProjectStatusEntity> projectStatusService,
            IHRepo<HProjectDesicionEntity> projectDesicionService,
            IHRepo<HFolderEntity> folderService,
            IHRepo<HTabEntity> tabService,
            IHRepo<HDocumentTypeEntity> documentTypeService,
            IMapper mapper,
            ILoggerFactory loggerFactory
            )
        {
            _positionService = positionService;
            _projectTypeService = projectTypeService;
            _projectStatusService = projectStatusService;
            _projectDesicionService = projectDesicionService;
            _tabService = tabService;
            _folderService = folderService;
            _documentTypeService = documentTypeService;
            _mapper = mapper;
            _logger = loggerFactory.CreateLogger(GetType());

        }
        /// <summary>
        /// Должности
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Типы проектов
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Состояния проектов
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Статусы проектов
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Вкладки
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Tabs()
        {
            try
            {
                var data = _mapper.Map<List<HTabViewModel>>(_tabService.Set());
                return Ok(data);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error while fetching Tabs Desicions {exception.Message}");
                throw exception;
            }
        }

        /// <summary>
        /// Папки
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Folders()
        {
            try
            {
                var data = await _folderService.Set().ProjectTo<HFolderViewModel>(_mapper.ConfigurationProvider).ToListAsync();
                return Ok(data);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error while fetching Tabs Desicions {exception.Message}");
                throw exception;
            }
        }

        /// <summary>
        /// Папки
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> HDocumentTypes()
        {
            try
            {
                var data = await _documentTypeService.Set().ProjectTo<HDocumentTypeViewModel>(_mapper.ConfigurationProvider).ToListAsync();
                return Ok(data);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Error while fetching Tabs Desicions {exception.Message}");
                throw exception;
            }
        }
    }
}

