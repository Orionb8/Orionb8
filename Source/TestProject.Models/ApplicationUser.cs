using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace DamuBala.Entities.Entities
{
    public class ApplicationUser : IdentityUser
    {
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
        /// ИИН
        /// </summary>
        public string IIN { get; set; }

        /// <summary>
        /// Тип пользователя
        /// </summary>
        public int? UserType { get; set; }
        public bool IsShared { get; set; }
        public bool IsImported { get; set; }
    }
}