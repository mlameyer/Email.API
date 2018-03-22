using Email.API.Repositories;
using Email.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Email.API
{
    public class Startup
    {
        public static IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appSettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
            //.AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddMvc()
                .AddMvcOptions(o => o.OutputFormatters.Add(
                    new XmlDataContractSerializerOutputFormatter()));
#if DEBUG
            services.AddTransient<ISendEmailRepository, SendEmailRepository>();
#else
            services.AddTransient<ISendEmailRepository, SendEmailRepository>();
#endif

            services.AddScoped<ISendEmailRepository, SendEmailRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(
                options => options.WithOrigins("http://www.dynamicsolutions.tech").AllowAnyMethod()
            );

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "SendMail",
                    template: "api/{SendMail}/{name}/{sendEmailAddress}/{subject}/{message}",
                    defaults: new { controller = "SendMail", Action = "Post" });
            });
        }
    }
}
//defaults: new { Key = UrlParameter.Optional, Code = UrlParameter.Optional, UserID = UrlParameter.Optional, Password = UrlParameter.Optional, Action = "Get" }
