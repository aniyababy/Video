using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Video.Appliacation.Contract.Code;
using Video.Appliacation.Contract.UserInfos.Dtos;
using Video.Application.Code;

namespace Video.HttpApi.Host.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeController : ControllerBase
    {
        private readonly ICodeService _codeService;

        public CodeController(ICodeService codeService)
        {
            _codeService = codeService;
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<string> GetAsync([FromQuery]CodeInput input)
        {
            return await _codeService.GetAsync(input);
        }
    }
}
