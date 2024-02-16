using System.Reflection;
using System.Text.Json.Serialization;
using Roadmap.Application;
using Roadmap.Application.Common.Mappings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Roadmap.Application.Interfaces;
using Roadmap.Persistance;
using Microsoft.OpenApi.Models;
using Minio;
using Roadmap.Application.Common.Helpers;

var builder = WebApplication.CreateBuilder(args);   
var services = builder.Services;
var endpoint = "localhost:9000";

var accessKey = "ydvnH3m2M7sJ0zGD";
var secretKey = "Sf5kvjYFVNuuryNfVbwotXlK6VUjKRoy";

services.AddMinio(configureClient => configureClient.WithEndpoint(endpoint).WithCredentials(accessKey, secretKey).WithSSL(false));

services.AddAutoMapper(config =>
{
    config.AddProfile(new MappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new MappingProfile(typeof(IAppDbContext).Assembly));
});

services.AddApplication();
services.AddPersistence(builder.Configuration);

services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(x =>
{
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),

        ValidateIssuer = false,
        ValidateAudience = false
    };
});
services.AddAuthorization();
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
services.AddEndpointsApiExplorer();

services.AddControllers()
    .AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

app.UseRouting();
app.UseHttpsRedirection();

app.UseSwaggerUI();
app.UseSwagger();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<AppDbContext>();
   
    }
    catch (Exception exception)
    {

    }
    

app.Run();
}

