using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Posts.Repository.Interface;
using Posts.Repository.Model;
using Posts.Repository.Repository;
using Posts.Service.Interface;
using Posts.Service.Service;

namespace Posts.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // Register Services
                    services.AddSingleton<MainWindow>();
                    services.AddScoped<IPostService, PostService>();
                    services.AddScoped<IPostRepository,PostRepository>();
                })
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Resolve MainWindow from DI and show it
            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.Dispose();
            base.OnExit(e);
        }
    }

}
