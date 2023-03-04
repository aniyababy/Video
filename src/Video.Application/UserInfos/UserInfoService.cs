using AutoMapper;

using FreeRedis;

using Simple.EntityFrameworkCore.Core.Base;

using Video.Appliacation.Contract.Base;
using Video.Appliacation.Contract.UserInfos;
using Video.Appliacation.Contract.UserInfos.Dtos;
using Video.Application.Contract.UserInfos.Dtos;
using Video.Application.Manage;
using Video.Domain.Shared;
using Video.Domain.Users;
using Video.EntityFrameworkCore.Users;

namespace Video.Application.UserInfos
{
    public class UserInfoService : IUserInfoService
    {
        private readonly IMapper _mapper;
        private readonly IUserInfoRespository _userInfoRepository;
        private readonly CurrentManage _currentManege;
        private readonly IUnitOfWork _unitOfWork;
        private readonly RedisClient _redisClient;

        public UserInfoService(IMapper mapper, IUserInfoRespository userInfoRespository, CurrentManage currentManege, IUnitOfWork unitOfWork, RedisClient redisClient)
        {
            _mapper = mapper;
            this._userInfoRepository = userInfoRespository;
            _currentManege = currentManege;
            _unitOfWork = unitOfWork;
            _redisClient = redisClient;
        }


        ///<inheritdoc/>
        public async Task<UserInfoRoleDto> LoginAsync(LoginInput input)
        {
            var data = await _userInfoRepository.GetUserInfoRoleViewAsync(input.UserName, input.Password);
            var dto = _mapper.Map<UserInfoRoleDto>(data);
            return dto;
        }
        ///<inheritdoc/>
        public async Task<UserInfoRoleDto> GetAsync()
        {
            var data = await _userInfoRepository.GetAsync(_currentManege.GetId());
            var dto = _mapper.Map<UserInfoRoleDto>(data);
            return dto;
        }

        public async Task updateAsync(UpdateUserInput input)
        {
            var userInfo = await _userInfoRepository.FirstOrDefaultAsync(x => x.Id == _currentManege.GetId());
            if(userInfo != null) 
            {
                throw new BusinessException("用户信息不存在"); 
            }
            userInfo.Avatar = input.Avatar;
            userInfo.Name = input.Name;
            userInfo.Password = input.Password;
            await _userInfoRepository.UpdateAsync(userInfo);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<UserInfoRoleDto> RegisterAsync(RegisterInput input)
        {
            var code = await _redisClient.GetAsync<string>($"{CodeType.Register}:{input.Username}");
            var s = $"{CodeType.Register}:{input.Username}";
            if (code != input.Code)
            {
                throw new BusinessException("验证码错误");
            }

            if (await _userInfoRepository.IsExistAsync(x => x.Username == input.Username))
            {
                throw new BusinessException("用户名已存在");
            }

            var data = _mapper.Map<UserInfo>(input);

            data = await _userInfoRepository.InsertAsync(data);

            await _unitOfWork.SaveChangeAsync();

            return _mapper.Map<UserInfoRoleDto>(data);
        }

        public async Task<PageResultDto<UserInfoDto>> GetListAsync(GetListInput input)
        {
            var data = await _userInfoRepository.GetListAsync(input.Keywords, input.StartTime, input.EndTime, input.SkipCount, input.MaxResultCount);

            var count = await _userInfoRepository.GetCountAsync(input.Keywords, input.StartTime, input.EndTime);
            var dto = _mapper.Map<List<UserInfoDto>>(data);
            return new PageResultDto<UserInfoDto>(count, dto);
        }

        public async Task DeletesAsync(IEnumerable<Guid> ids)
        {
            await _userInfoRepository.DeleteAsync(ids);
        }

        public async Task EnableAsync(IEnumerable<Guid> ids,bool enable = true)
        {
            await _userInfoRepository.EnableAsync(ids, enable);
        }

    }
}
