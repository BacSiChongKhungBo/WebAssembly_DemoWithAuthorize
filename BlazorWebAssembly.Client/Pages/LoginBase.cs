using BlazorWebAssembly.Client.IServices;
using Microsoft.AspNetCore.Components;
using Shared1.Models;

namespace BlazorWebAssembly.Client.Pages
{
    public class LoginBase : ComponentBase
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        
        [Inject]
        public ILoginService loginService { get; set; }

        public LoginUser loginUser { get; set; } = new LoginUser();

        protected override Task OnInitializedAsync()
        {
            return base.OnInitializedAsync();
        }

        protected async Task SubmitLoginForm()
        {
            var result = await loginService.LoginAsync(loginUser);
            if (result.IsSuccess)
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
