using CoursesAPI.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace CoursesAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // Configura��o dos servi�os
        builder.Services.ConfigureCors(MyAllowSpecificOrigins);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.ConfigureDatabase(builder.Configuration);
        builder.Services.ConfigureRepositories();
        builder.Services.ConfigureSwagger();

        var app = builder.Build();

        // Configura��o do pipeline de requisi��o HTTP
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors(MyAllowSpecificOrigins);
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
