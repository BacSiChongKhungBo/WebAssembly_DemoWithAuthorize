using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyAPI.IServices;
using Shared1.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyAPI.Services
{
    public class LoginService : ILoginService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        public LoginService(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<Response> LoginAsync(LoginUser loginUser)
        {
            // kieemr tra nguoi dung ton tai
            var user = await _userManager.FindByNameAsync(loginUser.Username);
            if (user == null && await _userManager.CheckPasswordAsync(user, loginUser.Password)) 
            {
                // get list roles of user
                var roles = await _userManager.GetRolesAsync(user);

                // create list of claims
                var claims = new List<Claim>()
                {
                    new Claim("id", user.Id.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.UserName.ToString()),
                    new Claim(ClaimTypes.Email, user.Email.ToString()),
                    new Claim(ClaimTypes.Role, roles.FirstOrDefault())
                };
                // Create JWT Token
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(_configuration["JWT:Issuer"]
                    , _configuration["JWT:Audience"], claims, expires: DateTime.UtcNow.AddDays(1),
                    signingCredentials: signIn);
                return new Response()
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Message = "Valid user",
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
                };
            }
            return new Response()
            {
                IsSuccess = false,
                StatusCode = 400,
                Message = "Invalid user"
            };
        }
    }
}
