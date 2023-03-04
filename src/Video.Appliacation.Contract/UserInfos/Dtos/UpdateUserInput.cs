using System;
using System.Collections.Generic;
using System.Text;

namespace Video.Appliacation.Contract.UserInfos.Dtos
{
    /// <summary>
    /// 编辑用户模型
    /// </summary>
    public class UpdateUserInput
    {
        /// <summary>
        /// 昵称
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string? Password { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string? Avatar { get; set; }
    }
}
