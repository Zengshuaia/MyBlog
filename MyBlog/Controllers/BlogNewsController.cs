using IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Model;
using MyBlog.Utility;

namespace MyBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogNewsController : ControllerBase
    {
        private readonly IBlogNewsService _iBlogNewsService;

        public BlogNewsController(IBlogNewsService iBlogNewsService)
        {
            this._iBlogNewsService = iBlogNewsService;
        }
        [HttpGet("Blog/{id}")]
        public async Task<ActionResult<ApiResult>> Get(int id)
        {
            var data =await _iBlogNewsService.QueryAsync();
            if (data == null) return ApiResultHelper.Error("没有更多的文章");
            return ApiResultHelper.Success(data);
        }
        /// <summary>
        /// 新增文章
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <param name="typeid"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<ApiResult> Create(string title,string content,int typeid)
        {
            BlogNews blog = new BlogNews
            {
                BrowseCount = 0,
                Context = content,
                LikeCount = 0,
                Time = DateTime.Now,
                WriteId = 1,
                TypeId = typeid,
                Title = title
            };
            bool result =await _iBlogNewsService.CreateAsync(blog);
            if (!result) return ApiResultHelper.Error("添加失败，服务器错误");
            return ApiResultHelper.Success(blog);
        }
        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("Delete")]
        public async Task<ApiResult> Delete(int id)
        {
            var result =await _iBlogNewsService.DeleteAsync(id);
            if (!result) return ApiResultHelper.Error("删除失败");
            return ApiResultHelper.Success(result);
        }
        /// <summary>
        /// 修改方法
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <param name="typeid"></param>
        /// <returns></returns>
        [HttpPut("Edit")]
        public async Task<ApiResult> Edit(int id,string title,string content,int typeid)
        {
            var blogNews =await _iBlogNewsService.FindAsync(id);
            blogNews.Title = title;
            blogNews.Context = content;
            blogNews.TypeId = typeid;
            bool result = await _iBlogNewsService.EditAsync(blogNews);
            if (!result) return ApiResultHelper.Error("修改错误");
            return ApiResultHelper.Success(blogNews);
        }
    }
}
