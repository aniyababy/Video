using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Video.Appliacation.Contract.Base;
using Video.Appliacation.Contract.Videos;
using Video.Appliacation.Contract.Videos.Dtos;
using Video.Domain.Videos;

namespace Video.HttpApi.Host.Controller
{
    /// <summary>
    /// 视频模块
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VideoController : ControllerBase
    {
        private readonly IVideoService _videoService;

        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        /// <summary>
        /// 发布视频
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public async Task CreatAsync(CreatVideoInput input)
        {
             await _videoService.CreatAsync(input);
        }

        /// <summary>
        /// 删除视频
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _videoService.DeleteAsync(id);
        }

        /// <summary>
        /// 获取视频列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<PageResultDto<GetVideoListDto>> GetListAsync([FromQuery]GetVideoListInput input)
        {
            return await _videoService.GetListAsync(input);
        }

        /// <summary>
        /// 管理员删除接口
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin1")]
        [HttpDelete("admin/id")]
        public async Task AdminDeleteAsync(Guid id)
        {
            await _videoService.AdminDeleteAsync(id);
        }


        /// <summary>
        /// 创建视频分类
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// 
        [HttpPost("classify")]
        public async Task CreatClassifyAsync(string name)
        {
            await _videoService.CreateClassifyAsync(name);
        }

        /// <summary>
        /// 删除视频分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpDelete("classify/{id}")]
        public async Task DeleteClassifyAsync(Guid id)
        {
            await _videoService.DeleteClassifyAsync(id);
        }

        /// <summary>
        /// 编辑视频分类
        /// </summary>
        /// <param name="classify"></param>
        /// <returns></returns>
        /// 
        [HttpPut("classify")]
        public async Task UpdateClassifyAsync(ClassifyDto classifydto)
        {
            await _videoService.UpdateClassifyAsync(classifydto);
        }

        /// <summary>
        /// 获取视频分类
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// 
        [HttpGet("classify/list")]
        public async Task<List<ClassifyDto>> GetListClassifyDtoAsync(string? name)
        {
            return await _videoService.GetListClassifyDtoAsync(name);
        }
    }
}
