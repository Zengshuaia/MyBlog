using IRepository;
using MyBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class WriteInfoRepository:BaseRepository<WriteInfo>,IWriteInfoRepository
    {
    }
}
