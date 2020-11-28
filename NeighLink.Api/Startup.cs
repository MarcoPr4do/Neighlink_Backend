using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NeighLink.DateLayer.Models;

namespace NeighLink.Api
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
            services.AddDbContext<neighlinkdbContext>();

            services.AddSwaggerGen( options =>
            {
                options.SwaggerDoc( "v2",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "NeighLink API V1",
                        Description = "Swagger API Neighlink",
                        Version = "v2"
                    } );
            } );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints( endpoints =>
             {
                 endpoints.MapControllers();
             } );

            app.UseSwagger();

            app.UseSwaggerUI( c =>
            {
                #if DEBUG
                    // For Debug in Kestrel
                    c.SwaggerEndpoint( "/swagger/v2/swagger.json", "Web API V1" );
                #else
                   // To deploy on IIS
                   c.SwaggerEndpoint("/webapi/swagger/v1/swagger.json", "Web API V1");
                #endif
            } );
        }
    }
}
