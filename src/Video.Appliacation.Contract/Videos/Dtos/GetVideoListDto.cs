using System;
using System.Collections.Generic;
using System.Text;

using Video.Appliacation.Contract.Base;

namespace Video.Appliacation.Contract.Videos.Dtos
{
    public class GetVideoListDto:EntityDto
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
    }
}
