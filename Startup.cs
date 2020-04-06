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
using ClassLibrary1.Infrastructure;
using ClassLibrary1.Interfaces;
using ClassLibrary1.Interfaces.SQLInterfaces.ISQLServices;
using ClassLibrary1.Interfaces.SQLInterfaces.ISQLRepositories;
using ClassLibrary1.Repository.SQLRepository;
using ClassLibrary1.Repository;
using ClassLibrary1.Services;
using ClassLibrary1.Services.SQL_Services;
using ClassLibrary1.UnitOfWork;


namespace WebApplication1
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
            #region SQL repositories
            services.AddTransient<ISQLReservationsRepository, ReservationsRepository>();
            #endregion

            #region SQL services
            services.AddTransient<ISQLReservationsService, SQLReservationsServices>();
            #endregion

            services.AddTransient<ISQLUnitOfWork, SQLUnitOfWork>();

            services.AddTransient<IConnectionFactory, ConnectionFactory>();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
