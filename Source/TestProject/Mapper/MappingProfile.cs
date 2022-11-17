using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Models;
using TestProject.Models.Dictionaries;
using TestProject.ViewModels;

namespace TestProject.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProjectEntity, ProjectViewModel>()
                .ReverseMap()
                .ForMember(x => x.HProjectDesicion, opts => opts.Ignore())
                .ForMember(x => x.HProjectStatus, opts => opts.Ignore())
                .ForMember(x => x.HProjectType, opts => opts.Ignore())
                .ForMember(x=>x.Team, opts=>opts.Ignore());
            CreateMap<EmployeeEntity, EmployeeViewModel>()
                .ReverseMap()
                .ForMember(x => x.Position, opts => opts.Ignore())
                .ForMember(x => x.Team, opts => opts.Ignore());
            CreateMap<HProjectDesicionEntity, HProjectDesicionViewModel>().ReverseMap();
            CreateMap<HProjectStatusEntity, HProjectStatusViewModel>().ReverseMap();
            CreateMap<HProjectTypeEntity, HProjectTypeViewModel>().ReverseMap();
            CreateMap<HPositionEntity, HPositionViewModel>().ReverseMap();
        }
    }
}
