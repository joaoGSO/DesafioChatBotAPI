using DesafioChatBotAPI.Services;

namespace DesafioChatBotAPI
{
    public class Startup
    {
        public Startup(IConfiguration configurations)
        {
            Configuration = configurations;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<RepositoriesServices>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder application, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                application.UseDeveloperExceptionPage();
            }

            application.UseHttpsRedirection();
            application.UseRouting();
            application.UseAuthorization();
            application.UseEndpoints(endpoints => 
            {
                endpoints.MapControllers();
            });
        }
    }
}
