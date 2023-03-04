using System;
using System.Collections.Generic;
using System.Text;
using Simple.EntityFrameworkCore.Core.Base;

namespace Video.Domain.Videos
{
    /// <summary>
    /// 关注表
    /// </summary>
    public class BeanVermicelli : Entity
    {
        //被关注人Id
        public Guid BeFocuseId { get; set; }
        //当前用户Id
        public Guid UserId { get; set; }

    }
}
