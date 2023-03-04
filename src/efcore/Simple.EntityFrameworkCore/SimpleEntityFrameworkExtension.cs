using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Simple.EntityFrameworkCore.Core;
using Simple.EntityFrameworkCore.Core.Base;

namespace Simple.EntityFrameworkCore
{
    public static class SimpleEntityFrameworkExtension
    {
        /// <summary>
        /// efcore核心扩展
        /// </summary>
        /// <typeparam name="IDbcontext"></typeparam>
        /// <param name="services"></param>
        /// <param name="options"></param>
        /// <param name="lifetime"></param>
        /// <returns></returns>
        public static IServiceCollection AddEntityFrameworkCore<IDbcontext>(
            this IServiceCollection services,
            Action<DbContextOptionsBuilder>? options = null,
            ServiceLifetime lifetime = ServiceLifetime.Singleton)
            where IDbcontext : MasterDbContext<IDbcontext>
        {
            services.AddDbContext<IDbcontext>(options, lifetime);
            services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork<IDbcontext>));
            return services;
        }   
    }
}
