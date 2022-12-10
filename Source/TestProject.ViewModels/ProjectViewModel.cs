using System;
using System.ComponentModel.DataAnnotations.Schema;
using TestProject.Models;

namespace TestProject.ViewModels
{
    public class ProjectViewModel:BaseViewModel<ProjectEntity>
    {
        public string Number { get; set; }
        public DateTime RegisterDate { get; set; }
        public HProjectTypeViewModel ProjectType { get; set; }
        public HProjectStatusViewModel ProjectStatus { get; set; }
        public HProjectDesicionViewModel ProjectDesicion { get; set; }
        public TeamViewModel Team { get; set; }
    }
}

