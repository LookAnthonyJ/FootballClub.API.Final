using AutoMapper;
using FootballClub.API.Infrastructure;
using FootballClub.Data;
using FootballClub.Models.Profiles;
using FootballClub.Services.Abstractions;
using FootballClub.Services.Implementations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballClub.API
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
            services.AddDbContext<FootballClubDbContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(Configuration.GetSection("ConnectionStrings").Get<ConnectionStrings>().DefaultConnection,
                    optionsBuilder =>
                    {
                        optionsBuilder.EnableRetryOnFailure();
                        optionsBuilder.CommandTimeout(60);
                        optionsBuilder.MigrationsAssembly("FootballClub.Data");
                    });
                options
                    .UseInternalServiceProvider(serviceProvider)
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            }).AddEntityFrameworkSqlServer();
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(typeof(PlayerProfile));
            }).CreateMapper();
            services.AddSingleton(mapper);
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<IClubService, ClubService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Football Club API", Version = "v1" });
            });
        }
       
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Football Club API v1"));
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
