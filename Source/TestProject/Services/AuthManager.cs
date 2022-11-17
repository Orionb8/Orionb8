using DamuBala.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TestProject.Services;
using TestProject.ViewModels;

namespace DamuBala.Core.Services
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private ApplicationUser _user;
        public AuthManager(UserManager<ApplicationUser> userManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<AuthenticatedUser> CreateToken(DamuBala.Entities.Entities.ApplicationUser user = null, string role = null)
        {

            if (_user == null)
                _user = user;

            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims(role);
            var token = GenerateTokenOptions(signingCredentials, claims);

            return new AuthenticatedUser
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                UserName = _user.UserName,
                Roles = claims.Select(s => s.Type).ToArray()
            };
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var expiration = DateTime.Now.AddMinutes(Convert.ToDouble(
                jwtSettings.GetSection("lifetime").Value));

            var token = new JwtSecurityToken(
                issuer: jwtSettings.GetSection("Issuer").Value,
                claims: claims,
                expires: expiration,
                signingCredentials: signingCredentials
                );

            return token;
        }

        private async Task<List<Claim>> GetClaims(string userRole = null)
        {
            var claims = new List<Claim>
             {
                 new Claim(ClaimTypes.Name, _user.UserName),
                 new Claim("Id", _user.Id),
             };

            var roles = await _userManager.GetRolesAsync(_user);
            if (roles.Count() == 1)
            {
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.ToUpper()));
                }
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole.ToUpper()));
            }

            return claims;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = "Rather_very_long_key";
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public async Task<bool> ValidateUser(LoginViewModel loginUserDTO)
        {
            _user = await _userManager.FindByEmailAsync(loginUserDTO.Email);
            var validPassword = await _userManager.CheckPasswordAsync(_user, loginUserDTO.Password);
            return (_user != null && validPassword);
        }
    }
}
