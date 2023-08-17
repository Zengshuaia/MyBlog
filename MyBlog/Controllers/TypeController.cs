using IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Model;
using MyBlog.Utility;

namespace MyBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly ITypeInfoService _iTypeInfoService;

        public TypeController(ITypeInfoService iTypeInfoService)
        {
            this._iTypeInfoService = iTypeInfoService;
        }
        [HttpGet("Types")]
        public async Task<ApiResult> GetType()
        {
            var types =await _iTypeInfoService.QueryAsync();
            return ApiResultHelper.Success(types);
        }
        [HttpPost("Create")]
        public async Task<ApiResult> Create(string name)
        {
            if (String.IsNullOrWhiteSpace(name)) return ApiResultHelper.Error("错误");
            TypeInfo type = new TypeInfo
            {
                Name = name
            };
            bool result = await _iTypeInfoService.CreateAsync(type);
            if (!result) return ApiResultHelper.Error("添加失败");
            return ApiResultHelper.Success(type);
        }
        [HttpDelete("Delete")]
        public async Task<ApiResult> Delete(int id)
        {
            var type =await _iTypeInfoService.FindAsync(id);
            if (type == null) return ApiResultHelper.Error("没有找到");
            var result = await _iTypeInfoService.DeleteAsync(id);
            if (!result) return ApiResultHelper.Error("删除失败");
            return ApiResultHelper.Success(result);
        }
        [HttpPut("Edit")]
        public async Task<ApiResult> Edit(int id,string name)
        {
            var type =await _iTypeInfoService.FindAsync(id);
            if (type == null) return ApiResultHelper.Error("没有找到");
            type.Name = name;
            var result = await _iTypeInfoService.EditAsync(type);
            if (!result) return ApiResultHelper.Error("修改失败");
            return ApiResultHelper.Success("修改成功");
        }
    }
}
