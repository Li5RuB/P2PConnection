using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.Extensions.Configuration;
using P2PConnect;
using P2PConnect.Configuration;
using System.Reflection;

namespace P2P.App
{
    public static class Program
    {
        public static async Task Main()
        {
            try
            {
                var applicationSettings = InitializeApplicationSettings();

                var windsorContainer = RegisterDependencies(applicationSettings);

                var rulesProcessing = windsorContainer.Resolve<ConnectProcessing>();

                await rulesProcessing.ProcessAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static ApplicationSettings InitializeApplicationSettings()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddUserSecrets(Assembly.GetEntryAssembly());

            var configuration = builder.Build();

            var applicationSettings = new ApplicationSettings();

            applicationSettings.Initialize(configuration);

            return applicationSettings;
        }

        private static IWindsorContainer RegisterDependencies(IApplicationSettings applicationSettings)
        {
            var container = new WindsorContainer();

            container.Register(Component.For<IApplicationSettings>().Instance(applicationSettings).LifestyleSingleton());
            
            container.Register(Component.For<ConnectProcessing>().LifestyleSingleton());

            return container;
        }
    }
}