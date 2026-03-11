using KasatotFireBase.Service;
using KasatotFireBase.Service.Firebase;
using Microsoft.Extensions.Logging;

namespace KasatotFireBase
{
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
			builder.RegisterServices()
				   .RegisterViewModels()
				   .RegisterViews();

#endif
			return builder.Build();
        }

		public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
		{
			// Register ViewModels for Dependency Injection			
			builder.Services.AddTransient<Views.SignInView>();
			builder.Services.AddTransient<Views.SignUpView>();			
			return builder;
		}
		public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
		{
			// Register ViewModels for Dependency Injection			
			builder.Services.AddTransient<ViewModels.SignInViewModel>();
			builder.Services.AddTransient<ViewModels.SignUpViewModel>();			
			return builder;
		}
		public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
		{
			builder.Services.AddSingleton<IAppLogger, LogService>();			
			builder.Services.AddSingleton<IAuthService, FirebaseAuthService>();
			return builder;
		}
	}
}
