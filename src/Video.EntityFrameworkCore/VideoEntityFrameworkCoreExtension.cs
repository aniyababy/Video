using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using Simple.EntityFrameworkCore.Mysql;

using Video.Domain.Users;
using Video.Domain.Videos;
using Video.EntityFrameworkCore.Users;
using Video.EntityFrameworkCore.Videos;

namespace Video.EntityFrameworkCore
{
    public static class VideoEntityFrameworkCoreExtension
    {
        public static IServiceCollection AddVideoEntityFrameworkCore(this IServiceCollection services)
        {
            //注入efcore
            services.AddMySqlEntityFrameworkCore<VideoDbContext>("Default");
            services.AddTransient<IUserInfoRespository,UserInfoRepository>();
            services.AddTransient<IVideoRespository, VideoRespository>();
            services.AddTransient<IBeanVermicelliRepository, BeanVermicelliRepository>();
            return services;
        }
    }
}
