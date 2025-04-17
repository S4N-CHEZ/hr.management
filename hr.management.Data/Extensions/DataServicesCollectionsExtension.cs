using hr.management.Data.Interfaces;
using hr.management.Data.Models;
using hr.management.Data.Services;
using Microsoft.Extensions.DependencyInjection;

namespace hr.management.Data.Extensions
{
    public static class DataServicesCollectionsExtension
    {
        public static void AddSerializationService(this IServiceCollection service)
        {
            service.AddSingleton<ISerializationService<Department>, XmlService<Department>>();
            service.AddSingleton<ISerializationService<Employee>, JsonService<Employee>>();
        }
    }
}
