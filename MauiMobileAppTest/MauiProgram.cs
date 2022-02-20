using System.Text.Json;
using MauiMobileAppTest.Data;
using Microsoft.EntityFrameworkCore;

namespace MauiMobileAppTest;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        using var stream = FileSystem.OpenAppPackageFileAsync("appsettings.json").Result;

        stream.Position = 0;
        var appSettings = JsonSerializer.Deserialize<AppSettings>(stream);
        builder.Services.AddSingleton(appSettings);

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddDbContext<AppDatabaseContext>(options => options.UseInMemoryDatabase("Todos"));
        var mauiApp = builder.Build();

        var dbContext = mauiApp.Services.CreateScope().ServiceProvider.GetRequiredService<AppDatabaseContext>();

        return mauiApp;
    }
}
