using System;
using System.Threading.Tasks;
using Microsoft.Windows.AppLifecycle;
using Windows.ApplicationModel.AppService;
using Windows.ApplicationModel.Background;

namespace Drizzle.WidgetProvider
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var instance = AppInstance.FindOrRegisterForKey("WidgetProvider");
            if (!instance.IsCurrent)
            {
                instance.RedirectActivationToAsync(instance.GetActivatedEventArgs()).AsTask().Wait();
                return;
            }

            BackgroundTaskDeferral deferral = null;
            AppServiceConnection connection = null;

            instance.Activated += (sender, e) =>
            {
                if (e.Kind == ExtendedActivationKind.AppService)
                {
                    var details = (AppServiceActivatedEventArgs)e.Data;
                    connection = details.AppServiceConnection;
                    deferral = details.GetDeferral();
                    connection.RequestReceived += OnRequestReceived;
                    connection.ServiceClosed += OnServiceClosed;
                }
            };

            await Task.Delay(-1);
        }

        private static void OnRequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
        {
            // Handle requests from the UWP app
        }

        private static void OnServiceClosed(AppServiceConnection sender, AppServiceClosedEventArgs args)
        {
            // Handle service closed event
        }
    }
}
