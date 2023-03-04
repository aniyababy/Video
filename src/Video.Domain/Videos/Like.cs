using System;
using System.Collections.Generic;
using System.Text;
using Simple.EntityFrameworkCore.Core.Base;
using Video.Domain.Users;

namespace Video.Domain.Videos
{
    /// <summary>
    /// 点赞表
    /// </summary>
    public class Like:Entity
    {
        //视频Id
        public Guid VideoId { get; set; }
        //用户Id
        public Guid UserId { get; set; }
        //点赞分类
        public LikeType Type { get; set; }
        public   UserInfo? User { get; set; }
        public virtual Video? Video { get; set; }
    }
}
