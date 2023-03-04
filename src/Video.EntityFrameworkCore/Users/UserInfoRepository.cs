using System.Data;
using System.Security.Cryptography.X509Certificates;

using Microsoft.EntityFrameworkCore;

using Simple.EntityFrameworkCore.Core;
using Simple.EntityFrameworkCore.Extensions;

using Video.Domain;
using Video.Domain.Users;

namespace Video.EntityFrameworkCore.Users
{
    public class UserInfoRepository : Repository<VideoDbContext, UserInfo>, IUserInfoRespository
    {
        public UserInfoRepository(VideoDbContext dbContext) : base(dbContext)
        {
        }


        public async Task<UserInfoRoleView?> GetUserInfoRoleViewAsync(string username, string password)
        {
            UserInfoRoleView? userInfo = await _dbContext.UserInfo.Where(x => x.Username == username && x.Password == password).Select(x => new UserInfoRoleView()
            {
                Username = x.Username,
                Password = x.Password,
                Avatar = x.Avatar,
                CreateTime = x.CreateTime,
                Enable = x.Enable,
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefaultAsync();
            if(userInfo == null)
            {
                return null;
            }
            ///获取当前用户的所有角色 
            var query =
                from role in _dbContext.Role
                join UserRole in _dbContext.userRole on role.Id equals UserRole.Id
                where UserRole.UserId == userInfo.Id
                select role;
            userInfo.Role = await query.ToListAsync();
            return userInfo;
        }

        public async Task<UserInfoRoleView?> GetAsync(Guid id)
        {
            UserInfoRoleView? userInfo = await _dbContext.UserInfo.Where(x=>x.Id==id).Select(x => new UserInfoRoleView()
            {
                Username = x.Username,
                Password = x.Password,
                Avatar = x.Avatar,
                CreateTime = x.CreateTime,
                Enable = x.Enable,
                Id = x.Id,
                Name = x.Name
            }).FirstOrDefaultAsync();
            if (userInfo == null)
            {
                return null;
            }
            ///获取当前用户的所有角色 
            var query =
                from role in _dbContext.Role
                join UserRole in _dbContext.userRole on role.Id equals UserRole.Id
                where UserRole.UserId == userInfo.Id
                select role;
            userInfo.Role = await query.ToListAsync();
            return userInfo;
        }

        public async Task<List<UserInfo>> GetListAsync(string? keywords, DateTime? startTime, DateTime? endTime, int skipCount, int maxResultCount)
        {
            var query = CreateQueryable(keywords, startTime, endTime);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync();
        }

        public async Task<int> GetCountAsync(string? keywords, DateTime? startTime, DateTime? endTime)
        {
            var query = CreateQueryable(keywords, startTime, endTime);
            return await query.CountAsync();
        }

        private IQueryable<UserInfo> CreateQueryable(string? keywords, DateTime? startTime, DateTime? endTime)
        {
            var query = _dbContext.UserInfo.WhereIf(!string.IsNullOrEmpty(keywords),x=>EF.Functions.Like(x.Name, keywords)&&EF.Functions.Like(x.Username,keywords))
                .WhereIf(startTime.HasValue,x=>x.CreateTime>=startTime)
                .WhereIf(endTime.HasValue,x=>x.CreateTime<=endTime);

            return query;
        }

        public async Task DeleteAsync(IEnumerable<Guid> ids)
        {
            await _dbContext.Database.ExecuteSqlRawAsync("DELETE FROM UserInfo WHERE Id IN {0}", string.Join(',', ids));
        }

        public async Task EnableAsync(IEnumerable<Guid> ids,bool enable = true)
        {
            await _dbContext.Database.ExecuteSqlRawAsync("UPDATE  UserInfo SET Enable = {0} WHERE Id IN ({1})",enable, string.Join(',',ids));
        }
    }
}
