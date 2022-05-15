using CrystalMindTask.Repo;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CrystalMindTask.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
