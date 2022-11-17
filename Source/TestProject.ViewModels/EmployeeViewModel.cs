using System;
using System.ComponentModel.DataAnnotations.Schema;
using TestProject.Models;
using TestProject.Models.Dictionaries;

namespace TestProject.ViewModels
{
	public class EmployeeViewModel :BaseViewModel<EmployeeEntity>
	{
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public HPositionViewModel Position { get; set; }
        public TeamViewModel Team { get; set; }
    }
}

