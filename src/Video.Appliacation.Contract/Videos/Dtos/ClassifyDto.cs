using System;
using System.Collections.Generic;
using System.Text;

using Video.Appliacation.Contract.Base;

namespace Video.Appliacation.Contract.Videos.Dtos
{
    public class ClassifyDto :EntityDto
    {
        /// <summary>
        /// 分类名称
        /// </summary>
        public string? Name { get; set; } 
    }
}
