using API_Demo.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared1.Models;

namespace API_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _registerService;

        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser registerUser, string role)
        {
            var result = await _registerService.RegisterAsync(registerUser, role);
            return StatusCode(result.StatusCode, result.Message);
        }
    }
}
