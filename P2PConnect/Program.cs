using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.Extensions.Configuration;
using P2PConnect;
using P2PConnect.Configuration;
using P2PConnectClient;
using P2PConnectHost;
using System.Reflection;
using System.Xml.Linq;

namespace P2P.App
{
    public static class Program
    {
        public static async Task Main(string[] agrs)
        {
            try
            {
                var applicationSettings = InitializeApplicationSettings();

                var windsorContainer = RegisterDependencies(applicationSettings);

                var rulesProcessing = windsorContainer.Resolve<ConnectProcessing>();

                await rulesProcessing.ProcessAsync(agrs);
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
                .AddEnvironmentVariables();

#if DEBUG
#pragma warning disable CS8604 // Possible null reference argument.
            builder.AddUserSecrets(Assembly.GetEntryAssembly());
#pragma warning restore CS8604 // Possible null reference argument.
#endif

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

            container.Register(
                Classes.FromAssemblyContaining(typeof(ProcessClient))
                    .Where(type => type.Name.Contains("Process")).WithService.DefaultInterfaces().LifestyleSingleton(),
                Classes.FromAssemblyContaining(typeof(ProcessHost))
                    .Where(type => type.Name.Contains("Process")).WithService.DefaultInterfaces().LifestyleSingleton()
                );

            return container;
        }
    }
}