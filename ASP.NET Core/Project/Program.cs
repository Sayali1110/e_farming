using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Project.Models;
using Steeltoe.Discovery.Client;//added

namespace Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //Required to remove cyclic dependancy error
            builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            builder.Services.AddDiscoveryClient(builder.Configuration);//added

            //builder.Services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowReactApp",
            //        policy => policy.WithOrigins("http://localhost:3000") 
            //                        .AllowAnyMethod()
            //                        .AllowAnyHeader());
            //});

            builder.Services.AddDbContext<p02_efarmingContext>();
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented = true;
            });

            builder.Services.AddCors(policybuilder => policybuilder.AddDefaultPolicy(policy => policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader()));

            var app = builder.Build();


            //app.UseCors("AllowReactApp");
            //app.MapControllers();
            //app.Run();

            //Cors
            app.UseCors(policy => policy.AllowAnyHeader()
                            .AllowAnyMethod()
                            .SetIsOriginAllowed(origin => true)
                            .AllowCredentials());


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();

            // Enable CORS Middleware
            app.UseCors("AllowReactApp");

            app.UseDiscoveryClient();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}




















