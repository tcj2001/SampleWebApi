//////////////////////////
// generated Startup.cs //
//////////////////////////
using Microsoft.OpenApi.Models;
using Serilog;
using Webapi.AppSetting;
using Webapi.Extensions;
using Webapi.Middlewares;

namespace Webapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //this is needed for Serilog.AspNetCore, Serilog.Settings.Configuration, Serilog.Sinks.File, Serilog.Sinks.Console,Serilog.Expressions
            //installed in application project,
            //this project has reference to application project
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // this has AddApplicationPart so that the controllers are referenced from Infrastructure.Presentation instead of Webapi
            services.AddControllers().AddApplicationPart(typeof(Infrastructure.Presentation.AssemblyReference).Assembly);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Webapi", Version = "v1" });

                //the following is only needed for swagger to enable basic authenication
                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "basic"
                            }
                        },
                        new string[] {}
                    }
                });

            });

            // added these for this project
            services.AddInfrastructure();
            services.AddApplication();

            //this is need for basic authentication
            services.Configure<BasicAuthentication>(Configuration.GetSection("BasicAuthentication"));

            //this is need for exception handling
            services.AddTransient<ExceptionHandlingMiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                    c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "Webapi v1");
                });
            }

            //added to handle basic authentication     
            app.UseBasicAuthMiddleware();

            //added to handle exceptions
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
