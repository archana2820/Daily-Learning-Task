using AutoMapper;
using MicroService.Application.common.Mappings;
using System;
using System.Linq;
using System.Reflection;

namespace MicroService.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingForAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingForAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces()
                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMappFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping") ??
                                 type.GetInterface("IMapFrom`1")?.GetMethod("Mapping");

                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
