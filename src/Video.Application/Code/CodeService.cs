using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FreeRedis;

using Video.Appliacation.Contract.Code;
using Video.Appliacation.Contract.UserInfos.Dtos;
using Video.Domain.Shared;

namespace Video.Application.Code
{
    public class CodeService : ICodeService
    {
        private readonly RedisClient _redisClient;

        public CodeService(RedisClient redisClient)
        {
            _redisClient = redisClient;
        }

        public async Task<string> GetAsync(CodeInput input)
        {
            var value = new Random().Next(9999).ToString("0000");
            // var s = $"{input.Type}:{input.value}";
            await _redisClient.SetExAsync($"{input.Type}:{input.value}", 60, value);

            return value;
        }
    }
}
