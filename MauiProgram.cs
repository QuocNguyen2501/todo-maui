using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Todo.CustomControls;
using Todo.Database;
using Todo.Database.Entities;
using Todo.Database.Repositories;
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
                    fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
                    fonts.AddFont("Poppins-SemiBold.ttf", "PoppinsSemiBold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            Microsoft.Maui.Handlers.ElementHandler.ElementMapper.AppendToMapping("Classic", (handler, view) =>
            {
                if (view is StandardEntry)
                    EntryMapper.Map(handler, view);
            });

            builder.Services.AddScoped<TodoDatabase>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            builder.Services.AddScoped<WelcomePageViewModel>();
            builder.Services.AddScoped<WelcomePage>();

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
