using AutoMapper;
using DamuBala.Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TestProject.Services;
using TestProject.ViewModels;

namespace TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IAuthManager _authManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IAuthManager authManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authManager = authManager;
        }

        [HttpPost]
        [Route("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] LoginViewModel loginDTO)
        {
            ApplicationUser user = await _userManager
                .FindByEmailAsync(loginDTO.Email.ToUpper());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var signSuccess = await _signInManager
                    .PasswordSignInAsync(user.UserName, loginDTO.Password, false, lockoutOnFailure: false);

                if (signSuccess.Succeeded)
                {
                    return Accepted(new
                    {
                        Token = await _authManager.CreateToken(user),
                        UserName = user.UserName,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        MiddleName = user.MiddleName,
                        Email = user.NormalizedEmail,
                        PhoneNumber = user.PhoneNumber,
                        UserId = user.Id
                    });
                }
                else
                {
                    return BadRequest("Incorrect password or email");
                }
            }
            catch (Exception exception)
            {
                return Problem($"Something Went Wrong in the {nameof(SignIn)}", statusCode: 500);
            }
        }
    }
}
