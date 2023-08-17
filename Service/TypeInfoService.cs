using IRepository;
using IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class TypeInfoService:BaseService<MyBlog.Model.TypeInfo>,ITypeInfoService
    {
        private readonly ITypeInfoRepository _iTypeInfoRepository;

        public TypeInfoService(ITypeInfoRepository iTypeInforRepository)
        {
            base._iBaseRepository = iTypeInforRepository;
            this._iTypeInfoRepository = iTypeInforRepository;
        }
    }
}
