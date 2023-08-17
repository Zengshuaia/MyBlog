using IRepository;
using IService;
using MyBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class BlogNewsService:BaseService<BlogNews>,IBlogNewsService
    {
        private readonly IBlogNewsRepository _iBlogNewsRepository;
        public BlogNewsService(IBlogNewsRepository iBlogNewsRepository)
        {
            base._iBaseRepository = iBlogNewsRepository;//传递给父类
            this._iBlogNewsRepository = iBlogNewsRepository;//子类独有
        }
    }
}
