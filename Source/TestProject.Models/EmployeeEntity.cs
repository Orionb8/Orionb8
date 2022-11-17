using System;
using System.ComponentModel.DataAnnotations.Schema;
using TestProject.Models.Dictionaries;

namespace TestProject.Models
{
	public class EmployeeEntity
	{
        public int Id { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary> 
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Должность
        /// </summary>
        public int PositionId { get; set; }
        [ForeignKey(nameof(PositionId))]
        public HPositionEntity Position { get; set; }
        /// <summary>
        /// Команда
        /// </summary>
        public int TeamId { get; set; }
        [ForeignKey(nameof(TeamId))]
        public TeamEntity Team { get; set; }
    }
}

