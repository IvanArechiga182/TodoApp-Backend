using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using TodoApp.Application;
using TodoApp.Data;
using TodoApp.Utils;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connectionString = GetConnectionString("todoApp", builder);
        configureServices(builder, connectionString);

        var app = builder.Build();

        configureApp(app);

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        app.Run();
    }


    private static string GetConnectionString(string dbname, WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString(dbname);

        if (string.IsNullOrWhiteSpace(connectionString))
            throw new Exception($"Connection string '{dbname}' is missing or invalid.");

        return connectionString;
    }


    private static void configureApp(WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    private static void configureServices(WebApplicationBuilder builder, string connectionString)
    {
        builder.Services.AddControllers().AddJsonOptions(
            opt =>
            {
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                opt.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                opt.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
                    )
                };
            });
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSingleton<Hashing>();
        builder.Services.AddDbContext<AppDbContext>(options =>
         options.UseMySql(
             connectionString,
             new MySqlServerVersion(new Version(8, 0, 36))
         )
     );
        builder.Services.AddServices();
    }
}