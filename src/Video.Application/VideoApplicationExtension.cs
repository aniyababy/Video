using Microsoft.Extensions.DependencyInjection;

using Video.Appliacation.Contract.Code;
using Video.Appliacation.Contract.UserInfos;
using Video.Appliacation.Contract.Videos;
using Video.Application.Code;
using Video.Application.Manage;
using Video.Application.UserInfos;
using Video.Application.Videos;

namespace Video.Application
{
    public static class VideoApplicationExtension
    {
        public static void AddVideoApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(VideoApplicationExtension).Assembly);

            services.AddTransient<IUserInfoService, UserInfoService>();

            services.AddTransient<CurrentManage>();

            services.AddTransient<ICodeService, CodeService>();

            services.AddTransient<IVideoService, VideoService>();

            services.AddTransient<IBeanVermicelliService, BeanVermicelliService>();
        }
    }
}