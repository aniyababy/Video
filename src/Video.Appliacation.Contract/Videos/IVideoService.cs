using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Video.Appliacation.Contract.Base;
using Video.Appliacation.Contract.UserInfos.Dtos;
using Video.Appliacation.Contract.Videos.Dtos;

namespace Video.Appliacation.Contract.Videos
{
    public interface IVideoService
    {
        /// <summary>
        /// 发布视频
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreatAsync(CreatVideoInput input);

        /// <summary>
        /// 删除视频
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// 管理员使用的删除接口
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task AdminDeleteAsync(Guid id);

        /// <summary>
        /// 获取视频列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PageResultDto<GetVideoListDto>> GetListAsync(GetVideoListInput input);


        /// <summary>
        /// 创建视频分类
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task CreateClassifyAsync(string name);

        /// <summary>
        /// 删除视频分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteClassifyAsync(Guid id);

        /// <summary>
        /// 编辑分类
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task UpdateClassifyAsync(ClassifyDto dto);

        /// <summary>
        /// 获取分类列表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<List<ClassifyDto>> GetListClassifyDtoAsync(string name);

        /// <summary>
        /// 是否删除当前视频文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<bool> WheatherItCanBeDelete(string path);




    }
}
