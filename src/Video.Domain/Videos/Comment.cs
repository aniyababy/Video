using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Simple.EntityFrameworkCore.Core.Base;
using Video.Domain.Users;

namespace Video.Domain.Videos
{
    public class Comment:Entity
    {
        //上级评论Id
        public Guid? ParantId { get; set; }
        //评论内容
        public string? Content { get; set; }
        //用户id
        public Guid UserId { get; set; }
        //视频id
        public Guid VideoId { get; set; }
        public virtual UserInfo? User { get; set; }
        public virtual Video? Video { get; set; }
    }
}
