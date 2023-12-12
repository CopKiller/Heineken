using Microsoft.Extensions.Logging;
//using Syncfusion.Maui.Core.Hosting;

namespace AplicativoPromotor
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

            // --> PDF Viewer
//            builder.ConfigureSyncfusionCore();

//#if DEBUG
//            builder.Logging.AddDebug();
//#endif

            return builder.Build();
        }
    }
}