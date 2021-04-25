using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SquareMetersValue.Api.Filters;
using SquareMetersValue.Domain.Commands;
using SquareMetersValue.Domain.Core;
using SquareMetersValue.Domain.Infra.Interfaces;
using SquareMetersValue.Infra.Configurations;
using SquareMetersValue.Infra.Repositories;

namespace SquareMetersValue.Api
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

            services.AddControllers();

            MongoDbPersistence.Configure();


            var assembly = AppDomain.CurrentDomain.Load("SquareMetersValue.Domain");

            services.AddMediatR(assembly);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SquareMetersValue.Api", Version = "v1" });
            });

            services.AddControllers(opt =>
            {
                opt.Filters.Add<MongoUnitOfWorkFilter>();
                opt.Filters.Add<NotificationFilter>();
            });

            services.AddMvc().AddFluentValidation(f =>
                f.RegisterValidatorsFromAssemblyContaining<CreatePropertyCommandValidation>());

            services.AddScoped<IMongoContext, MongoContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPropertiesRepository, PropertiesRepository>();

            services.AddScoped<NotificationContext>();

            services.AddScoped<ICitiesRepository, CitiesRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SquareMetersValue.Api v1"));
            }

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
