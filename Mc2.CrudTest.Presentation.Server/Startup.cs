using Mc2.Crud.Core.Domain;
using Mc2.Crud.Core.Entities;
using Mc2.Crud.Core.Persistence;
using Mc2.Crud.Service.Customer;
using Mc2.CrudTest.Presentation.Server.Filters;
using Mc2.CrudTest.Presentation.Server.Versioning;
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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server
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



            services.AddDbContext<SampleLibraryContext>(opts => opts.UseSqlServer(Configuration["ConnectionStrings:SampleLibraryDB"]));

            services.AddControllers(options =>
                options.Filters.Add(new AopExceptionHandlerFilter()));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICustomerService, CustomerService>();


            #region Swagger

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = " Clean Architecture v1 API's",
                    Description =
                        $"Clean Architecture API's for Ashkan Deliry \r\n\r\n � Copyright {DateTime.Now.Year} JK. All rights reserved."
                });
                swagger.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "v2",
                    Title = "Clean Architecture v2 API's",
                    Description =
                        $"Clean Architecture API's for Ashkan Deliry \r\n\r\n � Copyright {DateTime.Now.Year} JK. All rights reserved."
                });
                swagger.ResolveConflictingActions(a => a.First());
                swagger.OperationFilter<RemoveVersionFromParameterv>();
                swagger.DocumentFilter<ReplaceVersionWithExactValueInPath>();
            });

            #endregion

            #region Swagger Json property Support

            services.AddSwaggerGenNewtonsoftSupport();

            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(Microsoft.AspNetCore.Builder.IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer Test Project"));

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
