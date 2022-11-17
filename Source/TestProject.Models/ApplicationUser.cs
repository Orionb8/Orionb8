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
    }
}