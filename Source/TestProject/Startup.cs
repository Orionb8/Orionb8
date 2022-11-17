using DamuBala.Backend;
using DamuBala.Core.Services;
using DamuBala.Entities.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Text;
using TestProject.Data.Context;
using TestProject.Data.Converters;
using TestProject.Filters;
using TestProject.Interfaces;
using TestProject.Mapper;
using TestProject.Models;
using TestProject.Models.Dictionaries;
using TestProject.Mvc.Repo;
using TestProject.Services;

namespace TestProject
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
            services.AddCors(o =>
            {
                o.AddPolicy("AllowAll", builder =>
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"),
                                    b => b.MigrationsAssembly("TestProject.Data"));
            });

            services.AddMemoryCache();

            services.AddIdentity<ApplicationUser, IdentityRole>(config =>
            {
                //config.ClaimsIdentity. = "id";
                //config.SignIn.RequireConfirmedEmail = true;
            })
            .AddEntityFrameworkStores<DatabaseContext>()
            .AddDefaultTokenProviders();

            services.AddHttpContextAccessor();
            services.AddAuthentication();
            services.ConfigureIdentity();
            services.ConfigureJWT(Configuration);



            services.AddMvc();
            services.AddControllers();
            services.AddScoped<DbContext>(provider => provider.GetService<DatabaseContext>());
            services.AddAutoMapper(typeof(MappingProfile));
            ConfigureRepositories(services);

            services.AddControllersWithViews().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
                options.JsonSerializerOptions.MaxDepth = 10;
            });

            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TestProject.Backend", Version = "v1" });

                c.AddSecurityDefinition("Bearer", //Name the security scheme
                    new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme.",
                        Type = SecuritySchemeType.Http, //We set the scheme type to http since we're using bearer authentication
                        Scheme = "bearer" //The name of the HTTP Authorization scheme to be used in the Authorization header. In this case "bearer".
                    });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                                Id = "Bearer", //The name of the previously defined security scheme.
                                Type = ReferenceType.SecurityScheme
                            }
                        },new List<string>()
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowAll");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }

        public void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<IAuthManager, AuthManager>();
            services.AddScoped<IRepo<ProjectEntity>, BaseRepo<ProjectEntity>>();
            services.AddScoped<IRepo<EmployeeEntity>, BaseRepo<EmployeeEntity>>();
            services.AddScoped<IRepo<TeamEntity>, BaseRepo<TeamEntity>>();
            services.AddScoped<IHRepo<HPositionEntity>, BaseHRepo<HPositionEntity>>();
            services.AddScoped<IHRepo<HProjectDesicionEntity>, BaseHRepo<HProjectDesicionEntity>>();
            services.AddScoped<IHRepo<HProjectStatusEntity>, BaseHRepo<HProjectStatusEntity>>();
            services.AddScoped<IHRepo<HProjectTypeEntity>, BaseHRepo<HProjectTypeEntity>>();
        }
    }
}
