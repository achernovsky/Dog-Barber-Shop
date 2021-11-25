using Dog_Barber_Shop_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Dog_Barber_Shop_API.Repositories
{
    public class AuthenticationRepo : IAuthenticationRepo
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticationRepo(
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task RegisterClient(RegisterModel model)
        {
            ApplicationUser user = await Register(model);
            if (await roleManager.RoleExistsAsync(UserRoles.Client))
                await userManager.AddToRoleAsync(user, UserRoles.Client);
        }

        public async Task<ApplicationUser> Register(RegisterModel model)
        {
            var userExist = await userManager.FindByNameAsync(model.UserName);
            if (userExist != null)
                throw new Exception("User already exists");

            ApplicationUser user = new ApplicationUser()
            {
                Name = model.Name,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                throw new Exception("User creation failed");

            if (!await roleManager.RoleExistsAsync(UserRoles.Client))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Client));

            return user;
        }

        public async Task<JwtSecurityToken> Login(LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(5),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
                    );
                return token;
            }
            return null;
        }
    }
}
