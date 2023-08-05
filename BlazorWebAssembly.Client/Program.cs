using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorWebAssembly.Client;
using Blazored.LocalStorage;
using BlazorWebAssembly.Client.IServices;
using BlazorWebAssembly.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorWebAssembly.Client.Ultilities;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7293/") });
//add scoped của service 
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
await builder.Build().RunAsync();
