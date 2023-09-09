using Microsoft.AspNetCore.Components.WebView.Maui;
using FirstAppMaui.Data;
using FirstAppMaui.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace FirstAppMaui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif

        builder.Services.AddAuthorizationCore(options =>
        {
            options.AddPolicy("AdminPolicy",
                policy => policy.RequireClaim("role", "admin"));
        });


        builder.Services.AddScoped<CustomAuthStateProvider>();
        builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<CustomAuthStateProvider>());

        builder.Services.AddScoped<UserService>();
        builder.Services.AddScoped<CustomerService>();
        builder.Services.AddSingleton<WeatherForecastService>();

        return builder.Build();
    }
}
