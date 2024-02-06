using System.Reflection;
using Roadmap.Application;
using Roadmap.Application.Common.Mappings;
using Roadmap.Application.Interfaces;
using Roadmap.Persistance;

var builder = WebApplication.CreateBuilder(args);   
var services = builder.Services;

services.AddAutoMapper(config =>
{
    config.AddProfile(new MappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new MappingProfile(typeof(IRoadmapDbContext).Assembly));
});

services.AddApplication();
services.AddPersistence(builder.Configuration);
services.AddControllers();
var app = builder.Build();
app.MapControllers();




using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<RoadmapDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception exception)
    {

    }
    

app.Run();
}

