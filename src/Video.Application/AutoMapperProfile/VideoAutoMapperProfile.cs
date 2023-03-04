using AutoMapper;

using Video.Appliacation.Contract.Videos.Dtos;
using Video.Domain.Videos;

namespace Video.Application.AutoMapperProfile
{
    public class VideoAutoMapperProfile : Profile
    {
        public  VideoAutoMapperProfile()
        {
            CreateMap<CreatVideoInput, Domain.Videos.Video>();
            CreateMap<Domain.Videos.Video,GetVideoListDto>();
            CreateMap<ClassifyDto, Classify>().ReverseMap();
        }
    }
}
