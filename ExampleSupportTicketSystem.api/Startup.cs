using System.Text.Json;
using System.Threading.Tasks;
using ExampleSupportTicketSystem.Api.Models;
using ExampleSupportTicketSystem.Application.Concrete;
using ExampleSupportTicketSystem.Application.Interfaces;
using ExampleSupportTicketSystem.Application.Library;
using ExampleSupportTicketSystem.Domain.Interface;
using ExampleSupportTicketSystem.Domain.Models;
using ExampleSupportTicketSystem.Domain.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using System;

namespace ExampleSupportTicketSystem.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Add Open Api
            var XmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, XmlFile);

            services.AddSwaggerGen(prop =>
            {
                prop.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Support Ticket Api",
                    Description = "Example Support Ticket Api",
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                prop.IncludeXmlComments(xmlPath);
            });



            // Add Dependency Injection
            services.AddScoped<ICreateTicketRequestModel, CreateTicketRequestModel>();
            services.AddScoped<ICreateTicketResponseModel, CreateTicketResponseModel>();
            services.AddScoped<ICreateSupportTicket, CreateSupportTicket>();
            services.AddScoped<ICreateTicket, CreateTicket>();
            services.AddScoped<ISupportRepository, SupportRepository>();
            services.AddScoped<ITicketStatus, TicketStatus>();
            services.AddScoped<ITicket, Ticket>();
            services.AddScoped<ITicketResponseBuilder, TickerResponseBuilder>();


            // OAUTH2 - Using Local Identity Server 4
            // Note: this is not production ready, it needs locking down further.
            // i.e HTTPS required, Authority needs to be a FQDN and configurable.
            // Also we need to add token signing checks with the Idp through the public key 
            // (requested through the meta data url)
                /*
                 // Test Token Format
                 {
                        "nbf":1592991810,"exp":1592995410,
                        "iss":"http://localhost:5000",
                        "aud":["http://localhost:5000/resources","customAPI"],
                        "client_id":"clientApp",
                        "scope":["DEV_SCOPE_READER"]
                }
             */

            services.AddMvcCore()
                .AddAuthorization();

            services.AddAuthentication("Bearer")
                            .AddJwtBearer("Bearer", options => {
                                    options.Authority = "http://localhost:5000";
                                    options.RequireHttpsMetadata = false;
                                    options.Audience = "http://localhost:5000/resources";

                // Add logging
                options.Events = new Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents()
                {

                    OnAuthenticationFailed = c =>
                    {
                        // Add logging here / For now just write to a text file
                        Log.Debug(JsonSerializer.Serialize(c.Result));
                        return Task.CompletedTask;
                    }


                };
            
            });

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

            // OAUTH2
            app.UseAuthentication();
            app.UseAuthorization();

            // TODO: Add Logging (SeriLog?)
            // Added to Program.CS = SeriLog


            // Add Open Api
            app.UseSwagger();

            app.UseSwaggerUI(x => {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Example Support Ticket Api");
                x.RoutePrefix = string.Empty;
            }) ;


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
