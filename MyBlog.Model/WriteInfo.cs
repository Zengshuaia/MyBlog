
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model
{
    public class WriteInfo:BaseId
    {
        [SugarColumn(ColumnDataType ="nvarchar(12)")]
        public string Name { get; set; }
        [SugarColumn(ColumnDataType ="nvarchar(20)")]
        public string userName { get; set; }
        [SugarColumn(ColumnDataType ="nvarchar(20)")]
        public string usePwd { get; set; }
    }
}
