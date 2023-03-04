using AutoMapper;

using Video.Appliacation.Contract.Videos.Dtos;
using Video.Domain.Videos.Views;

namespace Video.Application.AutoMapperProfile
{
    public class BeanVermiceIIiAutoMapperProfile:Profile
    {
        public BeanVermiceIIiAutoMapperProfile() 
        {
            CreateMap<ConcernUserListView, GetConcernListDto>();
        }
    }
}
