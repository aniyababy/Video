using System;
using System.Collections.Generic;
using System.Text;

using Video.Domain.Shared;

namespace Video.Appliacation.Contract.UserInfos.Dtos
{
    public class CodeInput
    {
        /// <summary>
        /// 内容
        /// </summary>
        public string? value { get; set; }

        /// <summary>
        /// 验证码类型
        /// </summary>
        public CodeType Type { get; set; }
    }
}
