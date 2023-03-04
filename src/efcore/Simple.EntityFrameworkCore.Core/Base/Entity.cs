using System;

namespace Simple.EntityFrameworkCore.Core.Base
{
    public class Entity
    {
        //主键
        public Guid Id { get; set; }
        //创建时间
        public DateTime CreateTime { get; set; }

    }
}
