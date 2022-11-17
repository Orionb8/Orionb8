using System;
using System.ComponentModel.DataAnnotations.Schema;
using TestProject.Models.Dictionaries;

namespace TestProject.Models
{
    public class ProjectEntity : BaseEntity
    {
        /// <summary>
        /// Номер проекта
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// дата регистрации проекта
        /// </summary>
        public DateTime RegisterDate { get; set; }
        /// <summary>
        /// Тип проекта
        /// </summary>
        public int ProjecTypeId { get; set; }
        [ForeignKey(nameof(ProjecTypeId))]
        public HProjectTypeEntity HProjectType { get; set; }
        /// <summary>
        /// Статус проекта
        /// </summary>
        public int ProjectStatusId { get; set; }
        [ForeignKey(nameof(ProjectStatusId))]
        public HProjectStatusEntity HProjectStatus { get; set; }
        /// <summary>
        /// Решение по проекту
        /// </summary>
        public int ProjectDesicionId { get; set; }
        [ForeignKey(nameof(ProjectDesicionId))]
        public HProjectDesicionEntity HProjectDesicion { get; set; }

        /// <summary>
        /// Команда ответственная за проект
        /// </summary>
        public int TeamId { get; set; }
        [ForeignKey(nameof(TeamId))]
        public TeamEntity Team { get; set; }
    }
}

