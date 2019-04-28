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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ModulBank3.Services.Interfaces;
using ModulBank3.BusinessLogic;
using ModulBank3.Services;
using MassTransit;
using ModulBank3.Commands;
using ModulBank3.Consumers;
using Microsoft.Extensions.Hosting;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;


namespace ModulBank3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<GetUsersInfoRequestHandler>();
            services.AddScoped<IUserInfoService, UserInfoService>();

            services.AddScoped<AppendUsersRequestHandler>();
            //services.AddScoped<AppendUser, AppendUser>();



            // Обработчики событий MassTransit
            services.AddScoped<AppendUserConsumer>();

            services.AddMassTransit(x =>
            {
                x.AddConsumer<AppendUserConsumer>();
                x.AddBus(provider => MassTransit.Bus.Factory.CreateUsingInMemory(cfg =>
                {
                    cfg.ReceiveEndpoint("append-user-queue", ep =>
                    {
                        ep.ConfigureConsumer<AppendUserConsumer>(provider);
                        EndpointConvention.Map<AppendUserCommand>(ep.InputAddress);
                    });
                }));

                x.AddRequestClient<AppendUserCommand>();
            });

            services.AddSingleton<IHostedService, BusService>();



        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }

}
