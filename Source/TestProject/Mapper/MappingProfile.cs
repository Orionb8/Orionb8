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
                .ForMember(x => x.ProjectDesicion, opts => opts.Ignore())
                .ForMember(x => x.ProjectStatus, opts => opts.Ignore())
                .ForMember(x => x.ProjectType, opts => opts.Ignore())
                .ForMember(x => x.Team, opts => opts.Ignore());
            CreateMap<EmployeeEntity, EmployeeViewModel>()
                .ReverseMap()
                .ForMember(x => x.Position, opts => opts.Ignore())
                .ForMember(x => x.Team, opts => opts.Ignore());
            CreateMap<HProjectDesicionEntity, HProjectDesicionViewModel>().ReverseMap();
            CreateMap<HProjectStatusEntity, HProjectStatusViewModel>().ReverseMap();
            CreateMap<HProjectTypeEntity, HProjectTypeViewModel>().ReverseMap();
            CreateMap<HPositionEntity, HPositionViewModel>().ReverseMap();
            CreateMap<HTabEntity, HTabViewModel>().ReverseMap();
            CreateMap<HFolderEntity, HFolderViewModel>()
                .ReverseMap()
                .ForMember(x => x.HTab, opts => opts.Ignore());
            CreateMap<HDocumentTypeEntity, HDocumentTypeViewModel>()
                .ReverseMap()
                .ForMember(x => x.HTab, opts => opts.Ignore())
                .ForMember(x => x.HFolder, opts => opts.Ignore());
            CreateMap<DocumentEntity, DocumentViewModel>()
                .ReverseMap()
                .ForMember(x => x.HTab, opts => opts.Ignore())
                .ForMember(x => x.Project, opts => opts.Ignore())
                .ForMember(x => x.HFolder, opts => opts.Ignore())
                .ForMember(x => x.HDocumentType, opts => opts.Ignore())
                .ForMember(x => x.Upload, opts => opts.Ignore())
                ;
            CreateMap<TeamEntity, TeamViewModel>().ReverseMap();
            CreateMap<UploadEntity, UploadViewModel>().ReverseMap();
        }
    }
}
