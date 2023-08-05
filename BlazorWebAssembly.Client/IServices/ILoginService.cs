using Shared1.Models;

namespace BlazorWebAssembly.Client.IServices
{
    public interface ILoginService
    {
        Task<Response> LoginAsync(LoginUser loginUser);

        Task LogoutAsync();
    }
}
