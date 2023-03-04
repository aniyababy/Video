using System;
using System.Collections.Generic;
using System.Text;

namespace Video.Appliacation.Contract.Base
{
    public class EntityDto
    {
        //主键
        public Guid Id { get; set; }
        //创建时间
        public DateTime CreateTime { get; set; }

    }
}
