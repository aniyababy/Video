using AutoMapper;

using Video.Appliacation.Contract.Base;
using Video.Appliacation.Contract.Videos;
using Video.Appliacation.Contract.Videos.Dtos;
using Video.Application.Manage;
using Video.Domain.Videos;
using Video.Domain.Videos.Views;

namespace Video.Application.Videos
{
    public class BeanVermicelliService : IBeanVermicelliService
    {
        private readonly IBeanVermicelliRepository _beanVermicelliRepository;
        private readonly CurrentManage _currentManage;
        private readonly IMapper _mapper;

        public BeanVermicelliService(IBeanVermicelliRepository beanVermicelliRepository, CurrentManage currentManage, IMapper mapper)
        {
            _beanVermicelliRepository = beanVermicelliRepository;
            _currentManage = currentManage;
            _mapper = mapper;
        }
        /// <inheritdoc/>
        public async Task ConcernAsync(Guid userId)
        {
            //id为当用户id    userId为 视频发布者id
            var id = _currentManage.GetId();
            var data = await _beanVermicelliRepository.FirstOrDefaultAsync(x => x.UserId == userId&&x.BeFocuseId == userId);

            if(data != null)
            {
                //如果已关注 则取消关注
                await _beanVermicelliRepository.DeleteAsync(data.Id);
            }
            else
            {   //未关注 添加关注
                await _beanVermicelliRepository.InsertAsync(new BeanVermicelli()
                {
                    UserId = id,
                    BeFocuseId = userId,
                });
            }
        }

        /// <inheritdoc/>
        public async Task<PageResultDto<GetConcernListDto>> GetListAsync(Appliacation.Contract.Videos.Dtos.GetListInput input)
        {
            var data = await _beanVermicelliRepository.GetConcernUserList(input.UserId ?? _currentManage.GetId(), input.Keywords, input.Concern, input.Page, input.MaxResultCount);
            var count = await _beanVermicelliRepository.GetConcernUserCount(input.UserId ?? _currentManage.GetId(), input.Keywords, input.Concern);
            var dto = _mapper.Map<List<ConcernUserListView>, List<GetConcernListDto>>(data);
            return new PageResultDto<GetConcernListDto>(count,dto);
        }
    }
}
