using BlazorApp1.Shared;
using Microsoft.Extensions.DependencyInjection;
using BlazorApp1;
using Microsoft.AspNetCore.WebSockets;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpClient<IHotelBookingService, HotelBookingService>(client =>
        {
            client.BaseAddress = new Uri("https://localhost:7040/api/HotelBooking/");
        });

        services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin", builder =>
            {
                builder.WithOrigins("https://localhost:7034")
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();
            });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseWebSockets();
        app.UseCors("AllowSpecificOrigin");
    }
}
