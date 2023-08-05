using Shared1.Models;

namespace API_Demo.IServices
{
    public interface ILoginService
    {
        Task<Response> LoginAsync(LoginUser loginUser);
    }
}
