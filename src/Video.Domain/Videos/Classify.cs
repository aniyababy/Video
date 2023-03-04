using System;
using System.Collections.Generic;
using System.Text;
using Simple.EntityFrameworkCore.Core.Base;

namespace Video.Domain.Videos
{
    public class Classify:Entity
    {
        //分类名称
        public string? Name { get; set; }
    }
}
