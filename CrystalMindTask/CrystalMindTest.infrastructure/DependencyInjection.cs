using CrystalMindTask.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalMindTest.infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CrystalMindTaskDbContext>(options => options.UseSqlServer(connectionString!));

            services.AddScoped<ICrystalMindTaskDbContext>(provider => provider.GetService<CrystalMindTaskDbContext>()!);

            return services;
        }
        
    }
}
