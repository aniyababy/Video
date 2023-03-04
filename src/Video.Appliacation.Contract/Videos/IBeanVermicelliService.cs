using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Video.Appliacation.Contract.Base;

using Video.Appliacation.Contract.UserInfos.Dtos;
using Video.Appliacation.Contract.Videos.Dtos;

namespace Video.Appliacation.Contract.Videos
{
    /// <summary>
    /// 关注模块
    /// </summary>
    public interface IBeanVermicelliService
    {
        /// <summary>
        /// 关注用户 | 取消关注
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task ConcernAsync(Guid userId);

        /// <summary>
        /// 获取粉丝 | 关注 列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PageResultDto<GetConcernListDto>> GetListAsync(Dtos.GetListInput input);
    }
}
