
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Simple.EntityFrameworkCore.Mysql
{
    public static class SimpleEntityFrameworkCoreMySqlExtension
    { 
        public static IServiceCollection AddMySqlEntityFrameworkCore<IDbcontext>(this IServiceCollection services,string connect)
            where IDbcontext: MasterDbContext<IDbcontext>
        {
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            services.AddEntityFrameworkCore<IDbcontext>(x =>
            {
                x.UseMySql(configuration.GetConnectionString(connect),new MySqlServerVersion(new Version(8,0,32)));
            },ServiceLifetime.Singleton);
            return services;
        }
    }
}