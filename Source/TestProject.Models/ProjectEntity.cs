using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Models
{
    public class ProjectEntity : BaseEntity
    {
        public string Number { get; set; }
        public DateTime RegisterDate { get; set; }

        public int ProjecTypeId { get; set; }
        [ForeignKey(nameof(ProjecTypeId))]
        public HProjectTypeEntity HProjectType { get; set; }

        public int ProjectStatusId { get; set; }
        [ForeignKey(nameof(ProjectStatusId))]
        public HProjectStatusEntity HProjectStatus { get; set; }

        public int ProjectDesicionId { get; set; }
        [ForeignKey(nameof(ProjectDesicionId))]
        public HProjectDesicionEntity HProjectDesicion { get; set; }
    }
}

