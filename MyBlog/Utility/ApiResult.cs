namespace MyBlog.Utility
{
    public class ApiResult
    {
        public int code { get; set; }
        public string msg { get; set; }
        public int total { get; set; }
        public dynamic Data { get; set; }
    }
}
