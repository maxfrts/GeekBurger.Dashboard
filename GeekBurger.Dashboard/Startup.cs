using GeekBurger.Dashboard.Data;
using GeekBurger.Dashboard.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using GeekBurger.Dashboard.Repository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.EntityFrameworkCore.Infrastructure;
using GeekBurger.Dashboard.Service.Interfaces;
using GeekBurger.Dashboard.Service;

namespace GeekBurger.Dashboard
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appSettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                            new OpenApiInfo 
                            { 
                                Title = "Dashboard",
                                Version = "v1",
                                Description = "GeekBurger Dashboard Microservice Web API",
                                Contact = new OpenApiContact
                                {
                                    Name = "Maxwell Freitas",
                                    Email = "maxfrts@gmail.com",
                                    Url = null,
                                },
                            });
            });

            services.AddAutoMapper();

            var connString = Configuration["ConnectionStrings:SqlServerConnection"];
            services.AddSingleton(s => new DashboardContext(new DbContextOptionsBuilder<DashboardContext>().UseSqlServer(connString)));
            
            services.AddSingleton<IReceiveMessagesFactory, ReceiveMessagesFactory>();

            services.AddSingleton<IUserWithLessOfferRepository, UserWithLessOfferRepository>();
            services.AddSingleton<ISalesRepository, SalesRepository>();

            services.AddSingleton<IUserRestrictionsService, UserRestrictionsService>();
            services.AddSingleton<ISalesService, SalesService>();

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

            var mvcCoreBuilder = services.AddMvcCore();

            mvcCoreBuilder
                .AddFormatterMappings()
                .AddJsonFormatters();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseCors(options => options.AllowAnyOrigin());

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dashboard");
            });

            app.ApplicationServices.CreateScope().ServiceProvider.GetService<IReceiveMessagesFactory>();

            app.Run(async (context) =>
            {
                await context.Response
                   .WriteAsync("GeekBurger.Dashboard web api is running");
            });
        }
    }
}
