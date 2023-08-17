using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model
{
    public class BlogNews:BaseId
    {
        [SugarColumn(ColumnDataType="nvarchar(20)")]
        public string Title { get; set; }
        [SugarColumn(ColumnDataType ="text")]
        public string Context { get; set; }
        public DateTime Time { get; set; }
        public int BrowseCount { get; set; }
        public int LikeCount { get; set; }
        public int TypeId { get; set; }
        /// <summary>
        /// 不生成到数据库中,IsIgnore
        /// </summary>
        [SugarColumn(IsIgnore=true)]
        public TypeInfo TypeInfo { get; set; }
        public int WriteId { get; set; }
        [SugarColumn(IsIgnore=true)]
        public WriteInfo WriteInfo { get; set; }
    }
}
