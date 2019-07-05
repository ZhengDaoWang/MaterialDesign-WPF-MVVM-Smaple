using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.Library.Generator
{
    /// <summary>
    /// 数据库表结构
    /// </summary>
    public class TableStruct
    {
        /// <summary>
        /// 列名
        /// </summary>
        public string COLUMN_NAME { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public string DATA_TYPE { get; set; }

        /// <summary>
        /// 数据长度
        /// </summary>
        public Nullable<int> CHARACTER_MAXIMUM_LENGTH { get; set; }

        /// <summary>
        /// 注释
        /// </summary>
        public string VALUE { get; set; }

        /// <summary>
        /// 主键标记
        /// </summary>
        public bool ISPRIMARY { get; set; }
    }
}
