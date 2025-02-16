using CommunityToolkit.Maui;
using Firebase.Auth;
using Microsoft.Extensions.Logging;
using Todo.CustomControls;
using Todo.Database;
using Todo.Database.Repositories;
using Todo.Pages;
using Todo.Platforms;
using Todo.ViewModels;   
using Firebase.Auth.Providers;
using System.Reflection;
using Microsoft.Extensions.Configuration;


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
            
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream("Todo.appsettings.json")!;
            var config = new ConfigurationBuilder().AddJsonStream(stream).Build();
            builder.Configuration.AddConfiguration(config);

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            Microsoft.Maui.Handlers.ElementHandler.ElementMapper.AppendToMapping("Classic", (handler, view) =>
            {
                if (view is StandardEntry)
                    EntryMapper.Map(handler, view);
            });
            

            builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig(){
                ApiKey = builder.Configuration.GetValue<string>("FIREBASE_WEB_API_KEY"),
                AuthDomain =  builder.Configuration.GetValue<string>("FIREBASE_AUTH_DOMAIN"),
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            }));

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
