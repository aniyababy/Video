using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Simple.EntityFrameworkCore.Core.Base;
using Video.Domain.Videos.Views;

namespace Video.Domain.Videos
{
    public interface IBeanVermicelliRepository : IRepository<BeanVermicelli>
    {
        /// <summary>
        /// 获取粉丝|关注列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="keysords"></param>
        /// <param name="concern"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        Task<List<ConcernUserListView>> GetConcernUserList(Guid userId, string? keysords, bool concern, int page = 1, int pageSize = 20);

        /// <summary>
        /// 获取粉丝|关注数量
        /// </summary>
        /// <param name="id"></param>
        /// <param name="keyword"></param>
        /// <param name="concern"></param>
        /// <returns></returns>
        Task<int> GetConcernUserCount(Guid id, string? keyword, bool concern);
    }
}
