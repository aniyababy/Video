using System;
using System.Collections.Generic;
using System.Text;

using Video.Appliacation.Contract.Base;

namespace Video.Appliacation.Contract.Videos.Dtos
{
    public class GetConcernListDto:EntityDto
    {
        /// <summary>
        /// 昵称
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string? Username { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public string? Avatar { get; set; }

    }
}
