using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SquareMetersValue.Api.Filters;
using SquareMetersValue.Api.Settings;
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

            services.AddCors();
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);


            var assembly = AppDomain.CurrentDomain.Load("SquareMetersValue.Domain");

            services.AddMediatR(assembly);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Square Meters Value",
                    Version = "v1",
                    Description = "This api calculates the average value of the square meter in a given city ",
                    Contact = new OpenApiContact
                    {
                        Name = "Paulo Flausino",
                        Email = "calderaro95@hotmail.com",
                        Url = new Uri("https://github.com/pflausino/backend-challenge"),
                    },
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
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
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SquareMetersValue.Api v1"));

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                );

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
