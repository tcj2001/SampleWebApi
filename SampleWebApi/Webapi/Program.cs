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
                //this uses package Serilog.Extensions.Logging.File, its instaaled on the application project
                //allows to log error to a json file in the log folder of the startup project
                //.ConfigureLogging((_, builder) =>
                //{
                //    builder.AddFile("logs/app-{Date}.json", isJson: true);
                //})

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
