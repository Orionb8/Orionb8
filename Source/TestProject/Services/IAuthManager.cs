using System;
using System.Threading.Tasks;
using DamuBala.Entities.Entities;
using TestProject.ViewModels;

namespace TestProject.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LoginViewModel loginUserDTO);
        Task<AuthenticatedUser> CreateToken(ApplicationUser user = null, string role = null);
    }

}

