using System;
using System.Collections.Generic;
using System.Text;

namespace Video.Appliacation.Contract.Videos.Dtos
{
    /// <summary>
    /// 发布视频input
    /// </summary>
    public class CreatVideoInput
    {
        //标题
        public string? Title { get; set; }
        //描述
        public string? Description { get; set; }
        //视频地址
        public string? VideoUrl { get; set; }
        //分类Id
        public Guid ClassifyId { get; set; }
    }
}
