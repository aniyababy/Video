using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Simple.EntityFrameworkCore.Core.Base;

namespace Video.Domain.Users
{
    public interface IUserInfoRespository:IRepository<UserInfo>
    {
        /// <summary>
        /// 获取用户详细信息
        /// 包括角色
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<UserInfoRoleView?> GetUserInfoRoleViewAsync(string username,string password);

        /// <summary>
        /// 获取用户详细信息
        /// 包括角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserInfoRoleView?> GetAsync(Guid id);

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="skipCount"></param>
        /// <param name="maxResultCount"></param>
        /// <returns></returns>
        Task<List<UserInfo>> GetListAsync(string? keywords,DateTime? startDate,DateTime? endDate,int skipCount , int maxResultCount);

        /// <summary>
        /// 获取用户总数
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        Task<int> GetCountAsync(string? keywords,DateTime? startDate,DateTime? endDate);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(IEnumerable<Guid> id);

        /// <summary>
        /// 禁用用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task EnableAsync(IEnumerable<Guid> id,bool enable = true);

    }
}
