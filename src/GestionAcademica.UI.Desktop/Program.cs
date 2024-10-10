using GestionAcademica.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GestionAcademica.UI.Desktop
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(builder => builder.AddJsonFile("appsettings.local.json", optional: true))
                .ConfigureServices((context, services) => ConfigureServices(context.Configuration, services))
                .Build();

            var mainForm = host.Services.GetRequiredService<MainForm>();
            Application.Run(mainForm);
        }

        private static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services
                .AddMediatR(typeof(GestionAcademicaContext))
                .AddTransient<IDbContextFactory<GestionAcademicaContext>, SqliteDbContextFactory>()
                .AddSingleton<MainForm>()
                .AddTransient<EspecialidadesForm>();
        }
    }
}