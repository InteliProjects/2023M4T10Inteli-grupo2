using BackendECOTVOS.Data.Context;
using BackendECOTVOS.Repositories;
using BackendECOTVOS.Repositories.Interfaces;
using BackendECOTVOS.Services;
using BackendECOTVOS.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace BackendECOTVOS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:3000")
                                            .AllowAnyOrigin()
                                            .AllowAnyMethod()
                                            .AllowAnyHeader();
                    });
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register DbContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            builder.Services.AddScoped<IOperationRepository, OperationRepository>();
            builder.Services.AddScoped<IOperationService, OperationService>();
            builder.Services.AddScoped<ILogisticRepository, LogisticRepository>();
            builder.Services.AddScoped<ILogisticService, LogisticService>();
            builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
            builder.Services.AddScoped<IMaterialService, MaterialService>();
            builder.Services.AddScoped<IMaterialAssignmentRepository, MaterialAssignmentRepository>();
            builder.Services.AddScoped<IMaterialAssignmentService, MaterialAssignmentService>();
            builder.Services.AddScoped<IOperatorRepository, OperatorRepository>();
            builder.Services.AddScoped<IOperatorService, OperatorService>();
            builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
            builder.Services.AddScoped<IVehicleService, VehicleService>();
            builder.Services.AddScoped<ISupportTruckMaterialRepository, SupportTruckMaterialRepository>();
            builder.Services.AddScoped<ISupportTruckMaterialService, SupportTruckMaterialService>();
            builder.Services.AddScoped<IOperationMaterialsRepository, OperationMaterialsRepository>();
            builder.Services.AddScoped<IOperationMaterialsService, OperationMaterialsService>();
            
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors();


            app.MapControllers();

            app.Run();
        }
    }
}