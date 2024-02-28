using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using FluentAssertions.Common;

namespace PasserelleAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create the host builder
            var hostBuilder = CreateHostBuilder(args );

            // Build and run the host
            hostBuilder.Build().Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args )
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    _ = webBuilder.ConfigureServices(services =>
                    {
                        services.AddControllers();
                        services.AddEndpointsApiExplorer();
                        services.AddSwaggerGen(c =>
                        {
                            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "PasserelleAPI", Version = "v1" });
                        });
                    });

                    webBuilder.Configure((hostingContext, app) =>
                    {
                        var env = hostingContext.HostingEnvironment;

                        if (env.IsDevelopment())
                        {
                            app.UseSwagger();
                            app.UseSwaggerUI(c =>
                            {
                                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PasserelleAPI v1");
                            });
                        }
                       
                        app.UseHttpsRedirection();
                        app.UseAuthorization();

                                                
                    });
                });
        }
    }
}
