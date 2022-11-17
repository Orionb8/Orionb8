using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestProject.ViewModels
{
    public class LoginViewModel
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Required]
        [StringLength(15, ErrorMessage = "Your Password is limited to {2} to {1} characters", MinimumLength = 8)]
        public string Password { get; set; }

    }

    public class AuthenticatedUser
    {
        public string Token { get; set; }

        public string UserName { get; set; }

        public ICollection<string> Roles { get; set; }
    }
}
