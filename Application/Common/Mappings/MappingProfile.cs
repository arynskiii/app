using System.Reflection;
using System.Runtime.InteropServices;
using AutoMapper;

namespace Roadmap.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile(Assembly assembly)
    {
        ApplyMappingsFromAssembly(assembly);

        void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(type => type.GetInterfaces()
                    .Any(interfaceType => interfaceType.IsGenericType &&
                                          interfaceType.GetGenericTypeDefinition() == typeof(ImapWith<>)))
                .ToList();
            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var  methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
            
        }
    }
}
