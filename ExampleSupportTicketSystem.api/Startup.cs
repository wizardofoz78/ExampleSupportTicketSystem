using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleSupportTicketSystem.Api.Models;
using ExampleSupportTicketSystem.Application.Concrete;
using ExampleSupportTicketSystem.Application.Interfaces;
using ExampleSupportTicketSystem.Domain.Interface;
using ExampleSupportTicketSystem.Domain.Models;
using ExampleSupportTicketSystem.Domain.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ExampleSupportTicketSystem.Api
{
    public class Startup
    {
        

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();


            // Add Dependency Injection
            services.AddScoped<ICreateTicketRequestModel, CreateTicketRequestModel>();
            services.AddScoped<ICreateTicketResponseModel, CreateTicketResponseModel>();
            services.AddScoped<ICreateSupportTicket, CreateSupportTicket>();
            services.AddScoped<ICreateTicket, CreateTicket>();
            services.AddScoped<ISupportRepository, SupportRepository>();
            services.AddScoped<ITicketStatus, TicketStatus>();
            services.AddScoped<ITicket, Ticket>();



            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // TODO: Add Cors Support

            // TODO: Add HTTPS force.

            // TODO: Add support for OAUTH2 using Middle ware.

            // TODO: Add Logging (SeriLog?)

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
