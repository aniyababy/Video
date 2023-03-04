using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using System.Text;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using Video.Appliacation.Contract.UserInfos;
using Video.Appliacation.Contract.UserInfos.Dtos;
using Video.Application.UserInfos;
using Video.HttpApi.Host.Options;
using Video.Domain.Shared;

namespace Video.HttpApi.Host.Controller
{
    /// <summary>
    /// 授权认证
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserInfoService _userInfoService;
        private readonly JWTOptions jwtOptions;

        public AuthController(IUserInfoService userInfoService, IOptions<JWTOptions>Options)
        {
            _userInfoService = userInfoService;
            jwtOptions = Options.Value;
        }

        //登录
        [HttpPost]
        public async Task<string> PostAsync(LoginInput input)
        {
            var userInfo = await _userInfoService.LoginAsync(input);

            if (!userInfo.Enable)
            {
                throw new BusinessException("账号已被禁用请联系管理员");
            }

            // 设置角色
            var roles = userInfo.Role.Select(x => new Claim(ClaimsIdentity.DefaultRoleClaimType, x.Code!)).ToList();
            // 设置用户信息
            roles.Add(new Claim(ClaimsIdentity.DefaultIssuer, JsonSerializer.Serialize(userInfo)));
            roles.Add(new Claim(Constant.Id, userInfo.Id.ToString()));

            var keyBytes = Encoding.UTF8.GetBytes(jwtOptions.SecretKey!);
            var cred = new SigningCredentials(new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                jwtOptions.Issuer, // 签发者
                jwtOptions.Audience, // 接收者
                roles, // payload
                expires: DateTime.Now.AddMinutes(jwtOptions.ExpireMinutes), // 过期时间
                signingCredentials: cred); // 令牌

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
        /// <summary>
        /// 注册账号
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<string> RegsiterAsync(RegisterInput input)
        {
            var userInfo = await _userInfoService.RegisterAsync(input);

            // 设置角色
            var roles = userInfo.Role.Select(x => new Claim(ClaimsIdentity.DefaultRoleClaimType, x.Code!)).ToList();
            // 设置用户信息
            roles.Add(new Claim(ClaimsIdentity.DefaultIssuer, JsonSerializer.Serialize(userInfo)));
            roles.Add(new Claim(Constant.Id, userInfo.Id.ToString()));

            var keyBytes = Encoding.UTF8.GetBytes(jwtOptions.SecretKey!);
            var cred = new SigningCredentials(new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                jwtOptions.Issuer, // 签发者
                jwtOptions.Audience, // 接收者
                roles, // payload
                expires: DateTime.Now.AddMinutes(jwtOptions.ExpireMinutes), // 过期时间
                signingCredentials: cred); // 令牌

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}
