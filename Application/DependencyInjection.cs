using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minio;


namespace Roadmap.Application;

public  static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        // services.AddMinio(options =>
        // {
        //     var accessKey = "ydvnH3m2M7sJ0zGD";
        //     var secretKey = "Sf5kvjYFVNuuryNfVbwotXlK6VUjKRoy";
        //
        //     options.WithEndpoint("localhost:9000");
        //     options.WithCredentials(accessKey, secretKey);
        // });
        return services;
    }
}