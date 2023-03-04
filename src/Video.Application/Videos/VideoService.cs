using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;

using Simple.EntityFrameworkCore.Core.Base;

using Video.Appliacation.Contract.Base;
using Video.Appliacation.Contract.UserInfos.Dtos;
using Video.Appliacation.Contract.Videos;
using Video.Appliacation.Contract.Videos.Dtos;
using Video.Application.Manage;
using Video.Domain.Videos;

namespace Video.Application.Videos
{
    public class VideoService : IVideoService
    {
        private readonly IVideoRespository _videoRespository;
        private readonly IMapper _mapper;
        private readonly CurrentManage _currentManege;
        private readonly IUnitOfWork _unitOfWork;

        public VideoService(IVideoRespository videoRespository, IMapper mapper, CurrentManage currentManege, IUnitOfWork unitOfWork)
        {
            _videoRespository = videoRespository;
            _mapper = mapper;
            _currentManege = currentManege;
            _unitOfWork = unitOfWork;
        }

        public async Task AdminDeleteAsync(Guid id)
        {
            var video = await _videoRespository.FirstOrDefaultAsync(x => x.Id == id);
            if (video != null)
            {
                await _videoRespository.DeleteAsync(video);
                await _unitOfWork.SaveChangeAsync();
            }
        }

        /// <inheritdoc/>
        public async Task CreatAsync(CreatVideoInput input)
        {
            var data = _mapper.Map<Domain.Videos.Video>(input);
            var userid = _currentManege.GetId();
            data.UserId = userid;
            await _videoRespository.InsertAsync(data);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task CreateClassifyAsync(string name)
        {
            await _videoRespository.CreatClassifyAsync(name);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var video = await _videoRespository.FirstOrDefaultAsync(x=>x.Id== id&&x.UserId==_currentManege.GetId());
            if(video != null)
            {
                await _videoRespository.DeleteAsync(video);
                await _unitOfWork.SaveChangeAsync();
            }
        }

        public async Task DeleteClassifyAsync(Guid id)
        {
            await _videoRespository.DeleteClassifyAsync(id);
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<PageResultDto<GetVideoListDto>> GetListAsync(GetVideoListInput input)
        {
            var data = await _videoRespository.GetListAsync(input.UserId, input.ClassifyId, input.Keywords, input.StartTime, input.EndTime,input.SkipCount,input.MaxResultCount);
            var count = await _videoRespository.GetCountAsync(input.UserId, input.ClassifyId, input.Keywords, input.StartTime, input.EndTime);
            var dto = _mapper.Map<List<GetVideoListDto>>(data);
            return new PageResultDto<GetVideoListDto>(count,dto);
        }

        public async Task<List<ClassifyDto>> GetListClassifyDtoAsync(string name)
        {
            var data =await _videoRespository.GetListClassifyAsync(name);
            var dto = _mapper.Map<List<ClassifyDto>>(data);
            return dto;
        }

        public async Task UpdateClassifyAsync(ClassifyDto dto)
        {
            await _videoRespository.UpdateClassifyAsync(_mapper.Map<Classify>(dto));
            await _unitOfWork.SaveChangeAsync();
        }

        public async Task<bool> WheatherItCanBeDelete(string path)
        {
           var data = await _videoRespository.FirstOrDefaultAsync(x=>x.VideoUrl==path);
            //如果当前用户作者允许删除
            if(data.UserId==_currentManege.GetId())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
