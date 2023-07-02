using Autofac;
using Autofac.Core;
using Autofac.Core.Lifetime;
using Autofac.Extensions.DependencyInjection;
using BLogic;
using Hangfire;
using Hangfire.Dashboard;
using Hangfire.Logging;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using POS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace HangFireDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{

        //    services.AddControllers();
        //    //services.AddScoped<ITaskServices, MerchantService>();
        //    //services.AddControllers();
        //    //var builder = new ContainerBuilder();
        //    //builder.RegisterType<MerchantService>().As<ITaskServices>();
        //    //builder.Populate(services);

        //    //var container = builder.Build();
        //    //return new AutofacServiceProvider(container);

        //    //var descriptorToAdd = new ServiceDescriptor(typeof(ITaskServices),typeof(PosServices), ServiceLifetime.Scoped);
        //    //services.Replace(descriptorToAdd);

        //    //ServiceCollectionProvider.RegisterService = (IService, Service) =>
        //    //{
        //    //    //var descriptorToRemove = services.FirstOrDefault(d => d.ServiceType == typeof(ITaskServices));
        //    //    //services.Remove(descriptorToRemove);
        //    //    var descriptorToAdd = new ServiceDescriptor(IService, Service, ServiceLifetime.Scoped);
        //    //    services.Replace(descriptorToAdd);
        //    //    services.BuildServiceProvider();
        //    //    return services;
        //    //};

        //}

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            var builder = new ContainerBuilder();
            builder.RegisterModule<ServiceModules>();


            builder.Populate(services);
            var container = builder.Build();
            ServiceCollectionProvider.RegisterService = (IService, Service) =>
            {

                ContainerBuilder updater = new ContainerBuilder();
                updater.RegisterType(Service).As(IService);
                updater.Update(container);
                return services;
            };
            return new AutofacServiceProvider(container);
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
