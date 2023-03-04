using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

using Simple.EntityFrameworkCore.Core;
using Simple.EntityFrameworkCore.Extensions;

using Video.Domain.Users;
using Video.Domain.Videos;

namespace Video.EntityFrameworkCore.Videos
{
    public class VideoRespository : Repository<VideoDbContext, Domain.Videos.Video>, IVideoRespository

    {
        public VideoRespository(VideoDbContext dbContext) : base(dbContext)
        {
        }

        public async Task CreatClassifyAsync(string name)
        {
            await _dbContext.Classify.AddAsync(new Classify()
            {
                Name = name
               
            });
        }

        public async Task DeleteClassifyAsync(Guid id)
        {
            var data =await  _dbContext.Classify.FirstOrDefaultAsync(x => x.Id == id);
            if(data!=null)
            {
                _dbContext.Classify.Remove(data);
            }
        }

        public async Task<List<Classify>> GetListClassifyAsync(string? name)
        {
            return await _dbContext.Classify.WhereIf(string.IsNullOrEmpty(name), x => EF.Functions.Like(x.Name,$"%{name}%")).ToListAsync();
        }

        ///<inheritdoc/>
        public async Task<int> GetCountAsync(Guid? userId, Guid? classifyId, string? keywords, DateTime? startTime, DateTime? endTime)
        {
            var query = CreatQuery(userId, classifyId, keywords, startTime, endTime);
            return await query.CountAsync();
        }

        ///<inheritdoc/>
        public async Task<List<Domain.Videos.Video>> GetListAsync(Guid? userId, Guid? classifyId, string? keywords, DateTime? startTime, DateTime? endTime, int skipCount, int maxResultCount)
        {
            var query = CreatQuery(userId, classifyId, keywords, startTime, endTime);
            return await query.PageBy(skipCount,maxResultCount).ToListAsync();
        }

        public async Task UpdateClassifyAsync(Classify classify)
        {
             _dbContext.Classify.Update(classify);
            await Task.CompletedTask;
        }

        private IQueryable<Domain.Videos.Video> CreatQuery(Guid? userId, Guid? classifyId, string? keywords, DateTime? startTime, DateTime? endTime)
        {
            var query =
                _dbContext.Video
                .WhereIf(userId.HasValue, x => x.UserId == userId)
                .WhereIf(classifyId.HasValue, x => x.ClassifyId == classifyId)
                .WhereIf(!string.IsNullOrEmpty(keywords), x => EF.Functions.Like(x.Title, $"%{keywords}%"))
                .WhereIf(startTime.HasValue, x => x.CreateTime >= startTime)
                .WhereIf(endTime.HasValue, x => x.CreateTime <= endTime);
            return query;

        }

        public async Task<int> StatisticalConcernAsync(Guid userId, DateTime? startTime, DateTime? endTime)
        {
          return await _dbContext.BeanVermicelli
                 .WhereIf(startTime.HasValue, x => x.CreateTime >= startTime)
                 .WhereIf(endTime.HasValue, x => x.CreateTime <= endTime)
                 .Where(x => x.UserId == userId)
                 .CountAsync();
        }

        public async Task<int> ReleaseCountasync(Guid userId, DateTime? startTime, DateTime? endTime)
        {
            return await _dbContext.Video
                    .WhereIf(startTime.HasValue, x => x.CreateTime >= startTime)
                    .WhereIf(endTime.HasValue, x => x.CreateTime <= endTime)
                    .Where(x => x.UserId == userId)
                    .CountAsync();
        }
    }
}
