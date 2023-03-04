using AutoMapper;

using Video.Appliacation.Contract;
using Video.Appliacation.Contract.UserInfos.Dtos;
using Video.Application.Contract.UserInfos.Dtos;
using Video.Domain;
using Video.Domain.Users;

namespace Video.Application.AutoMapperProfile
{
    public class UserInfoAutoMapperFile:Profile
    {
        public UserInfoAutoMapperFile() 
        {
            CreateMap<UserInfo, UserInfoDto>().ReverseMap();

            CreateMap<UserInfoRoleView, UserInfoRoleDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();

            CreateMap<UserInfo,UserInfoRoleDto>().ReverseMap();
            CreateMap<RegisterInput, UserInfo>();
        }
    }
}
