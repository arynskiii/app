using System.Reflection;
using Roadmap.Application;
using Roadmap.Application.Common.Mappings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Roadmap.Application.Interfaces;
using Roadmap.Persistance;
using System.Text;
using Microsoft.OpenApi.Models;
using Roadmap.Application.Common.Helpers;

var builder = WebApplication.CreateBuilder(args);   
var services = builder.Services;

services.AddAutoMapper(config =>
{
    config.AddProfile(new MappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new MappingProfile(typeof(IAppDbContext).Assembly));
});

services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),

        ValidateIssuer = false,
        ValidateAudience = false
    };
});
services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition($"Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            BearerFormat = "JWT",
            Scheme = "Bearer",
            Name = "Authorization",
            Description = "Authorization token"
        });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                 
                },
                Scheme = "Bearer",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new string[] { }
        }
    });
});
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddControllersWithViews();
services.AddSession();
services.AddApplication();
services.AddPersistence(builder.Configuration);
services.AddControllers();
services.AddAuthentication();
services.AddAuthorization();
var app = builder.Build();
app.UseSwaggerUI();
app.UseSwagger();
app.MapControllers();
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<AppDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception exception)
    {

    }
    

app.Run();
}

