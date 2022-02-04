//////////////////////////
// generated Program.cs //
//////////////////////////
using Serilog;

namespace Webapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                //this is needed for Serilog.AspNetCore, Serilog.Settings.Configuration, Serilog.Sinks.File, Serilog.Sinks.Console, Serilog.Expressions
                //installed in application project,
                //this project has reference to application project
                .UseSerilog()

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseIISIntegration();
                    webBuilder.UseStartup<Startup>();
                });
    }
}
