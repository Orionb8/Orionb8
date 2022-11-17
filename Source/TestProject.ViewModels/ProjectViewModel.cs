using System;
using System.ComponentModel.DataAnnotations.Schema;
using TestProject.Models;

namespace TestProject.ViewModels
{
    public class ProjectViewModel:BaseViewModel<ProjectEntity>
    {
        public string Number { get; set; }
        public DateTime RegisterDate { get; set; }
        public HProjectTypeViewModel HProjectType { get; set; }
        public HProjectStatusViewModel HProjectStatus { get; set; }
        public HProjectDesicionViewModel HProjectDesicion { get; set; }
        public TeamViewModel Team { get; set; }
    }
}

