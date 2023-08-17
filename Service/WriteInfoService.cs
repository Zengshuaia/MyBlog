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
    public class WriteInfoService:BaseService<WriteInfo>,IWriteInfoService
    {
        private readonly IWriteInfoRepository _iWriteInfoService;

        public WriteInfoService(IWriteInfoRepository iWriteInfoService)
        {
            base._iBaseRepository = iWriteInfoService;
            this._iWriteInfoService = iWriteInfoService;
        }
    }
}
