using Countdown.Api.Services;
using Countdown.Api.Services.Interfaces;
using Countdown.Core.Letters;
using Countdown.Core.Letters.Interfaces;
using Countdown.Core.Numbers;
using Countdown.Core.Numbers.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Countdown.Api
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
            // Add framework services.
            services.AddMvc();
            services.AddCors();
            services.AddScoped<INumbersSolver, NumbersSolver>();
            services.AddScoped<INumbersService, NumbersService>();
            services.AddScoped<IWordList, WordListSowpods>();
            services.AddScoped<IWordFinder, WordFinder>();
            services.AddScoped<ILettersSolver, LettersSolver>();
            services.AddScoped<ILettersService, LettersService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            var appSettings = Configuration.GetSection("AppSettings");
            app.UseCors(
                options => options.WithOrigins(appSettings.GetValue<string>("PermittedOrigin")).AllowAnyMethod()
            );
            app.UseMvc();
        }
    }
}
