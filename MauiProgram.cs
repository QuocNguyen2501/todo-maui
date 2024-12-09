using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Todo.CustomControls;
using Todo.Pages;
using Todo.Platforms;
using Todo.ViewModels;

namespace Todo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            Microsoft.Maui.Handlers.ElementHandler.ElementMapper.AppendToMapping("Classic", (handler, view) =>
            {
                if (view is StandardEntry)
                    EntryMapper.Map(handler, view);
            });

            builder.Services.AddSingleton<WelcomePageViewModel>();
            builder.Services.AddSingleton<WelcomePage>();

            builder.Services.AddScoped<RegisterPageViewModel>();
            builder.Services.AddScoped<RegisterPage>();

            builder.Services.AddScoped<LoginPageViewModel>();
            builder.Services.AddScoped<LoginPage>();

            builder.Services.AddScoped<HomePageViewModel>();
            builder.Services.AddScoped<HomePage>();

            return builder.Build();
        }
    }
}
