using SqlSugar;

namespace MyBlog.Utility
{
    public static class ApiResultHelper
    {
        //成功后返回的数据
        public static ApiResult Success(dynamic data)
        {
            return new ApiResult
            {
                Data = data,
                code = 200,
                msg = "操作成功",
                total = 0
            };
        }
        //分页
        public static ApiResult Success(dynamic data,RefAsync<int> totla)
        {
            return new ApiResult
            {
                Data = data,
                code = 200,
                msg = "操作成功",
                total = totla
            };
        }
        //错误
        public static ApiResult Error(string msg)
        {
            return new ApiResult
            {
                Data = null,
                code = 500,
                msg = "msg",
                total = 0
            };
        }
    }
}
