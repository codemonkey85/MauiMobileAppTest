using MauiMobileAppTest.Data;
using Microsoft.EntityFrameworkCore;

namespace MauiMobileAppTest;

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

        builder.Services.AddDbContext<AppDatabaseContext>(options => options.UseInMemoryDatabase("Todos"));

        return builder.Build();
    }
}
