using CCPolandAPI.DAL.Data;
using CCPolandAPI.DAL.Repositories;
using CCPolandAPI.DAL.Repositories.Interfaces;
using CCPolandAPI.DAL.Repositories.Interfaces.IModel;
using CCPolandAPI.Models.DTOS.Material;
using CCPolandAPI.Services.ErrorHandling.Middleware;
using CCPolandAPI.Services.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace CCPolandAPI
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

            services.AddControllers().AddFluentValidation().AddNewtonsoftJson();


            services.AddCors(options =>
                options.AddDefaultPolicy(builder =>
                    builder.AllowAnyOrigin()));


            services.AddScoped<Seeder>();
            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddScoped<IValidator<MaterialModifyDto>, MaterialModifyDtoValidator>();
            services.AddScoped<IAuthorRepo, AuthorRepo>();
            services.AddScoped<IGenreRepo, GenreRepo>();
            services.AddScoped<IMaterialRepo, MaterialRepo>();
            services.AddScoped<IReviewRepo, ReviewRepo>();

            services.AddDbContext<CCPolandDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("CCPolandDbContext")));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "CodeCoolPolandAPI",
                    Description = "This API helps all CodeCool Students to become better programmers \n\n" +
                    "Author: Karol Bieniaszewski",
                    Version = "v1" });

                var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
                c.IncludeXmlComments(filePath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Seeder seeder)
        {
            seeder.Seed();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CCPolandAPI v1"));
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
