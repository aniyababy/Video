using System;
using System.Collections.Generic;
using System.Text;

using Video.Appliacation.Contract.Base;

namespace Video.Appliacation.Contract.Videos.Dtos
{
    public class GetVideoListInput:VideoInput
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid? UserId { get; set; }
        /// <summary>
        /// 分类ID
        /// </summary>
        public Guid? ClassifyId { get; set; }
    }
}
