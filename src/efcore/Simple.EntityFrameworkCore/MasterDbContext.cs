using Microsoft.EntityFrameworkCore;

namespace Simple.EntityFrameworkCore
{
    public class MasterDbContext<TDbcontext>:DbContext where TDbcontext: DbContext 
    {
        protected MasterDbContext(DbContextOptions<TDbcontext> options) : base(options) 
        { 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //全局禁用跟踪查询
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution);

#if DEBUG
            //显示更详细的异常日志
            optionsBuilder.EnableDetailedErrors();
#endif
        }

    }
}