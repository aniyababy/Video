using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Video.Appliacation.Contract.Base;
using Video.Appliacation.Contract.UserInfos.Dtos;
using Video.Appliacation.Contract.Videos.Dtos;
using Video.Application.Contract.UserInfos.Dtos;

namespace Video.Appliacation.Contract.UserInfos
{
    public interface IUserInfoService 
    {

        /// <summary>
        /// 登录账号 获取用户信息
        /// </summary>
        /// <returns></returns>
        Task<UserInfoRoleDto> LoginAsync(LoginInput input);

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        Task<UserInfoRoleDto> GetAsync();

        /// <summary>
        /// 编辑用户信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task updateAsync(UpdateUserInput input);

        /// <summary>
        /// 注册账号
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<UserInfoRoleDto> RegisterAsync(RegisterInput input);

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PageResultDto<UserInfoDto>> GetListAsync(Dtos.GetListInput input);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeletesAsync(IEnumerable<Guid> id);

        /// <summary>
        /// 禁用用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task EnableAsync(IEnumerable<Guid> id,bool enable = true);

    }
}
