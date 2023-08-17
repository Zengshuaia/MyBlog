using IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TypeInfoRepository:BaseRepository<MyBlog.Model.TypeInfo>,ITypeInfoRepository
    {
    }
}
