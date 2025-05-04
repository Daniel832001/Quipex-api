using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quipex.Application.Interfaces;
using Quipex.Persistence.QueryDataStores;
using Quipex.Persistence.Repositories;

namespace Quipex.Persistence;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<ICompanyRecordQueryDataStore, CompanyRecordQueryDataStore>();
        services.AddScoped<ICompanyRecordRepository, CompanyRecordRepository>();

        // Register your DbContext too if needed
        // services.AddDbContext<ReadDbContext>(...);

        return services;
    }
}
