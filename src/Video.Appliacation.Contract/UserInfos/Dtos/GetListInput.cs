using System;
using System.Collections.Generic;
using System.Text;

using Video.Appliacation.Contract.Base;

namespace Video.Appliacation.Contract.UserInfos.Dtos
{
    public class GetListInput:VideoInput
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
        /// 密码
        /// </summary>
        public string? Password { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string? Avatar { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enable { get; set; } = true;
    }
}
