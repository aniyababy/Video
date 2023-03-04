using System;
using System.Collections.Generic;
using System.Text;
using Simple.EntityFrameworkCore.Core.Base;
using Video.Domain.Users;

namespace Video.Domain.Videos
{
    /// <summary>
    /// 视频表
    /// </summary>
    public  class Video:Entity
    {
        //标题
        public string? Title { get; set; }
        //描述
        public string? Description { get; set; }
        //视频地址
        public string? VideoUrl { get; set; }
        //分类Id
        public Guid ClassifyId { get; set; }
        //用户Id (视频发布者)
        public Guid UserId { get; set; }
        public virtual UserInfo? User { get; set; }
        public virtual Classify? Classify { get; set; }
    }
}
