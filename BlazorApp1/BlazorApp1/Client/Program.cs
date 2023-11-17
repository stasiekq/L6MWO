using BlazorApp1.Client;
using BlazorApp1.Shared;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient<IHotelBookingService, HotelBookingService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7040/api/HotelBooking/");
});

await builder.Build().RunAsync();
