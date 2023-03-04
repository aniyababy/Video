using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using Video.Appliacation.Contract.Videos;
using Video.Domain.Shared;
using Video.HttpApi.Host.Options;

namespace Video.HttpApi.Host.Controller
{
    /// <summary>
    /// 文件管理
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FileController : ControllerBase
    {

        private readonly IVideoService _videoService;

        public FileController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="file"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public async Task<string> UpLoad(IFormFile file,FileType type)
        {
            //获取当前程序集目录 文件存储目录
            var path = Path.Combine(AppContext.BaseDirectory,"wwwroot",type.ToString().ToLower());
            if(!Directory.Exists(path))
            { 
                Directory.CreateDirectory(path);
            }
            //if(file.Length>_videoFileOptions.MaxFileSize*1024)
            //{
            //    throw new BusinessException("文件大小不得超过设置的值");
            //}

            //生成文件名
            var fileName =  Guid.NewGuid().ToString("N") + file.FileName;
            //创建文件 并打开  使用using语法糖释放资源
            using var fileStream = System.IO.File.Create(Path.Combine(path, fileName));
            //将数据流 拷贝进文件
            await file.OpenReadStream().CopyToAsync(fileStream);
            await fileStream.FlushAsync();
            fileStream.Close();
            return type.ToString().ToLower()+"/"+fileName;
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task DeleteAsync(string path)
        {
            path = Path.Combine(AppContext.BaseDirectory, "wwwroot");

            if(System.IO.File.Exists(path))
            {
                if (await _videoService.WheatherItCanBeDelete(path))
                {
                    System.IO.File.Delete(path);
                }
                else
                {
                    throw new BusinessException("您没有权限删除");
                }
            }
        }
    }
}
