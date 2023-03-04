using System.Data.Common;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Simple.EntityFrameworkCore;
using Video.Domain;
using Video.Domain.Users;
using Video.Domain.Videos;

namespace Video.EntityFrameworkCore
{
    public class VideoDbContext :MasterDbContext<VideoDbContext>
    {
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> userRole { get; set; }
        public DbSet<Domain.Videos.Video> Video { get; set; }
        public DbSet<Like> Like { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Classify> Classify { get; set; }
        public DbSet<BeanVermicelli> BeanVermicelli { get; set; }

        public VideoDbContext(DbContextOptions<VideoDbContext> options):base(options) 
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserInfo>(u =>
            {
                u.ToTable("UserInfo");
                u.HasComment("用户表");
                u.HasKey(x => x.Id);
                u.HasIndex(x => x.Id);
                u.Property(x => x.Username).HasComment("用户名");
                u.HasIndex(x=>x.Username).IsUnique();
            });

            builder.Entity<Role>(x =>
            {
                x.ToTable("Roles");
                x.HasComment("角色表");
                x.HasKey(x => x.Id);
                x.HasIndex(x => x.Id);
            });

            builder.Entity<UserRole>(x =>
            {
                x.ToTable("UserRoles");
                x.HasComment("用户角色配置表");
                x.HasKey(x=> x.Id);
                x.HasIndex(x => x.Id);
                x.HasIndex(x => x.UserId);
                x.HasIndex(x => x.RoleId);
            });

            builder.Entity<Domain.Videos.Video>(x =>
            {
                x.ToTable("Videos");
                x.HasComment("视频表");
                x.HasKey(x=> x.Id);
                x.HasIndex(x => x.Id);
                x.HasIndex(x => x.ClassifyId);
                x.HasIndex(x => x.UserId);
            });

            builder.Entity<Like>(x =>
            {
                x.ToTable("Likes");
                x.HasComment("点赞表");
                x.HasKey(x=>x.Id);
                x.HasIndex(x => x.Id);
                x.HasIndex(x => x.UserId);
                x.HasIndex(x => x.VideoId);
            });

            builder.Entity<Comment>(x =>
            {
                x.ToTable("Comments");
                x.HasComment("评论表");
                x.HasKey(x => x.Id);
                x.HasIndex(x => x.Id);
                x.HasIndex(x => x.UserId);
                x.HasIndex(x => x.ParantId);
            });

            builder.Entity<Classify>(x =>
            {
                x.ToTable("Classifys");
                x.HasComment("视频分类表");
                x.HasKey(x => x.Id);
                x.HasIndex(x => x.Id);
            });

            builder.Entity<BeanVermicelli>(x =>
            {
                x.ToTable("BeanVermicellis");
                x.HasComment("关注表");
                x.HasKey(x => x.Id);
                x.HasIndex(x=>x.Id);
                x.HasIndex(x => x.UserId);
                x.HasIndex(x => x.BeFocuseId);
            });
            #region 初始化数据
            var userInfo = new UserInfo()
            {
                Id = Guid.NewGuid(),
                Avatar = "",
                CreateTime = DateTime.Now,
                Enable = true,
                Name = "admin",
                Username = "adminn",
                Password = "adminn",
            };

            var role = new Role()
            {
                Id = Guid.NewGuid(),
                Name = "admin",
                Code = "admin"
            };

            var user = new Role()
            {
                Id = Guid.NewGuid(),
                Name = "user",
                Code = "user"
            };

            var userRole = new UserRole()
            {
                Id = Guid.NewGuid(),
                RoleId = role.Id,
                UserId = userInfo.Id,
            };

            builder.Entity<UserInfo>().HasData(userInfo);
            builder.Entity<Role>().HasData(role, user);
            builder.Entity<UserRole>().HasData(userRole);
            #endregion
        }
    }
}