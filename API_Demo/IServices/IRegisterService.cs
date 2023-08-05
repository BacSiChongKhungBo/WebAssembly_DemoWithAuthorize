using Shared1.Models;

namespace API_Demo.IServices
{
    public interface IRegisterService
    {
        Task<Response> RegisterAsync(RegisterUser registerUser, string role);
        Task<Response> AddToUserAsync(RegisterUser registerUser);
        Task<Response> AddToCartAsync(RegisterUser registerUser);

    }
}
