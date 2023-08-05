using Blazored.LocalStorage;
using BlazorWebAssembly.Client.IServices;
using BlazorWebAssembly.Client.Ultilities;
using Microsoft.AspNetCore.Components.Authorization;
using Shared1.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace BlazorWebAssembly.Client.Services
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient httpClient;
        private readonly ILocalStorageService localStorageService;
        private readonly AuthenticationStateProvider authenticationStateProvider;

        public LoginService(HttpClient httpClient, ILocalStorageService localStorageService, AuthenticationStateProvider authenticationStateProvider)
        {
            this.httpClient = httpClient;
            this.localStorageService = localStorageService;
            this.authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<Response> LoginAsync(LoginUser loginUser)
        {
            // post kết quả lên api
            var result = await this.httpClient.PostAsJsonAsync("/api/Login", loginUser);
            // lấy kết quả
            var contentJSON = await result.Content.ReadAsStringAsync();
            var loginResponse = JsonSerializer.Deserialize<Response>(contentJSON, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

            if(!result.IsSuccessStatusCode)
            {
                return loginResponse;
            }
            await this.localStorageService.SetItemAsync("authToken", loginResponse.Token);
            ((CustomAuthenticationStateProvider)this.authenticationStateProvider).MarkUserAsAuthenticatedAsync(loginUser.Username);
            this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResponse.Token);
            return loginResponse;

        }

        public async Task LogoutAsync()
        {
            await this.localStorageService.RemoveItemAsync("authToken");
            ((CustomAuthenticationStateProvider)this.authenticationStateProvider).MarkUserAsLoggedOut();
            this.httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
