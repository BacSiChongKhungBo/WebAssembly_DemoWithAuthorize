using Shared1.Models;

namespace MyAPI.IServices
{
    public interface ILoginService
    {
        Task<Response> LoginAsync(LoginUser loginUser);

    }
}
