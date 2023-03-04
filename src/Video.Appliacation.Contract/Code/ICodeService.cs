using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Video.Appliacation.Contract.UserInfos.Dtos;
using Video.Domain.Shared;

namespace Video.Appliacation.Contract.Code
{
    public interface ICodeService
    {
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<string> GetAsync(CodeInput input);

    }
}
