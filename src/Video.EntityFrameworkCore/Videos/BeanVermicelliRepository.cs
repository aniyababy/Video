using Microsoft.EntityFrameworkCore;

using Simple.EntityFrameworkCore.Core;
using Simple.EntityFrameworkCore.Extensions;
using Video.Domain.Videos;
using Video.Domain.Videos.Views;

namespace Video.EntityFrameworkCore.Videos
{
    public class BeanVermicelliRepository : Repository<VideoDbContext, BeanVermicelli>, IBeanVermicelliRepository
    {
        public BeanVermicelliRepository(VideoDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<int> GetConcernUserCount(Guid id, string? keyword, bool concern)
        {
            var query = CreateConcernUserQuery(id, keyword, concern);
            return await query.CountAsync();
        }

        /// <summary>
        /// 获取关注列表 并分页
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="keysords"></param>
        /// <param name="concern"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<ConcernUserListView>> GetConcernUserList(Guid userId, string? keywords, bool concern, int page = 1, int pageSize = 20)
        {
            var query = CreateConcernUserQuery(userId, keywords, concern);

            return await query.PageBy(page, pageSize).ToListAsync();
        }
        private IQueryable<ConcernUserListView> CreateConcernUserQuery(Guid userId, string? keywords, bool concern)
        {
            var beanVermicellis = _dbContext.BeanVermicelli.Where(x => concern ? x.UserId == userId : x.UserId == userId);
            IQueryable<ConcernUserListView> query;
            if (concern)
            {
                query =
                from bean in beanVermicellis
                join users in _dbContext.UserInfo on bean.BeFocuseId equals users.Id into user
                from u in user.DefaultIfEmpty()
                select new ConcernUserListView(u.Id, u.Name, u.Username, u.Avatar);
            }
            else
            {
                query =
               from bean in beanVermicellis
               join users in _dbContext.UserInfo on bean.UserId equals users.Id into user
               from u in user.DefaultIfEmpty()
               select new ConcernUserListView(u.Id, u.Name, u.Username, u.Avatar);
            }
            query = query.WhereIf(!string.IsNullOrEmpty(keywords), x => x.Name.Contains(keywords) || x.Username.Contains(keywords));
            return query;
        }
    }
}
