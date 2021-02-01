using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Weather.Domain.Ports;
using Weather.Domain.Services;
using Weather.Domain.UseCases;

namespace Weather
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddMvc().AddNewtonsoftJson();

            var config = new ConfigurationBuilder().AddJsonFile("appconfig.json").Build();
            string apiUrl = config["Api:Url"];
            string apiKey = config["Api:Key"];

            IApiConfigPort apiConfig = new ApiConfigService(apiUrl, apiKey);
            IRequestCurrentWeather requestCurrentWeatherService = new ForecastRequestService(apiConfig);
            IRequestForecast requestForecastService = new ForecastRequestService(apiConfig);
            IGetCurrentWeather getCurrentWeatherService = new ForecastService(requestCurrentWeatherService, requestForecastService);
            IGetForecast getForecast = new ForecastService(requestCurrentWeatherService, requestForecastService);

            services.AddSingleton<IGetCurrentWeather>(provider => getCurrentWeatherService);
            services.AddSingleton<IGetForecast>(provider => getForecast);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
