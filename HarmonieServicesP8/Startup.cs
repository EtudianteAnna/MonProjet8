using Serilog;

namespace HarmonieServicesP8
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
                // specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "HarmonieServiceP8");
                });
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // Configure logging
        public void ConfigureLogging(ILoggingBuilder logging)
        {
            // Configure Serilog to write logs to a file
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("Logs/myapp-{Date}.txt")
                .CreateLogger();

            // Use Serilog for logging
            logging.AddSerilog();
        }
    }
}
