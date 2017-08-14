using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;


namespace LoginRegistration
{
    public class Startup
    {
       
        public void ConfigureServices(IServiceCollection services)
        {
        
            services.AddSession();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder App, ILoggerFactory LoggerFactory)
        {
            LoggerFactory.AddConsole();
            App.UseDeveloperExceptionPage();
            App.UseStaticFiles();
            App.UseSession();
            App.UseMvc();
            // App.UseIdentity();
        }
    }
}
