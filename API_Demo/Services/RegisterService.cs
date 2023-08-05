using API_Demo.Data;
using API_Demo.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Shared1.Models;

namespace API_Demo.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _applicationDbContext;

        public RegisterService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext applicationDbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Response> RegisterAsync(RegisterUser registerUser, string role)
        {
            if(await _userManager.FindByEmailAsync(registerUser.Email) != null)
            {
                return new Response
                {
                    IsSuccess = true,
                    StatusCode = 402,
                    Message = "This mail already exist"
                };
            } 
            else if (await _userManager.FindByNameAsync(registerUser.Username) != null) 
            {
                return new Response
                {
                    IsSuccess = true,
                    StatusCode = 401,
                    Message = "This username already exist"
                };
            }

            //check pass
            if(registerUser.Password != registerUser.ConfirmPassword)
            {
                return new Response
                {
                    IsSuccess = true,
                    StatusCode = 400,
                    Message = "password not match"
                };
            }
            IdentityUser identityUser = new()
            {
                UserName = registerUser.Username,
                Email = registerUser.Email,
            };

            if(await _roleManager.RoleExistsAsync(role))
            {
                var result = await _userManager.CreateAsync(identityUser, registerUser.Password);

                if (!result.Succeeded)
                {
                    return new Response
                    {
                        IsSuccess = true,
                        StatusCode = 500,
                        Message = "failed something went wrong"
                    };
                }

                //Bổ sung role cho user đăng kí
                await _userManager.AddToRoleAsync(identityUser, role);
                //thêm vào bảng user
                await _applicationDbContext.Users.AddAsync(new User()
                { UserName = registerUser.Username });
                await _applicationDbContext.SaveChangesAsync();
                //tạo 1 cart với user: Giải thích, khi đăng kí xong, sẽ tạo 1 giỏ hàng cho user đó luôn
                var temp= _applicationDbContext.Users.Where(x => x.UserName.Equals(registerUser.Username)).FirstOrDefault();
                await _applicationDbContext.Carts.AddAsync(new Cart()
                { UserId = temp.Id }
                );
                await _applicationDbContext.SaveChangesAsync();
                return new Response
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Message = "register successed"
                };

            }
            else
            {
                return new Response
                {
                    IsSuccess = true,
                    StatusCode = 404,
                    Message = "role not exist"
                };
            }
        }

        public async Task<Response> AddToCartAsync(RegisterUser registerUser)
        {
            var temp = await (_applicationDbContext.Users.FindAsync(registerUser.Username));
            await _applicationDbContext.Carts.AddAsync(new Cart()
            { UserId = temp.Id }
            );
            return new Response
            {
                IsSuccess = true,
                StatusCode = 200,
                Message = "Add Cart Successed"
            };
        }

        public async Task<Response> AddToUserAsync(RegisterUser registerUser)
        {
            await _applicationDbContext.Users.AddAsync(new User() 
            { UserName = registerUser.Username }
            );
            return new Response
            {
                IsSuccess = true,
                StatusCode = 200,
                Message = "Add User Successed"
            };
        }
    }
}
