using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Token.Domain.Interfaces;
using Token.Domain;
using Token.Infra.Data;
using Token.Infra.Data.Repository;
using Token.Service.Services;

namespace Token.Presentation
{
    /// <summary>
    /// Startup class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Startup method
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuration method
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //Add Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "RDI Token API"
                });
            });

            services.AddDbContext<TokenContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("TokenDatabase")
                    )
            );

            services.AddScoped(typeof(TokenContext));
            services.AddScoped(typeof(IService<>), typeof(TokenService<>));
            services.AddScoped(typeof(IToken), typeof(GenerateToken));
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository <>));

            services.AddMvc();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "RDI Token API"); });

            app.UseMvc();

            // Set swagger as default page
            app.Run(async context => {
                context.Response.Redirect("swagger/index.html");
            });
        }
    }
}
