using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.Library.Generator
{
    public class GeneratorTools
    {
        /// <summary>
        /// 将SQLServer数据类型（如：varchar）转换为.Net类型（如：String）
        /// </summary>
        /// <param name="sqlTypeString">SQLServer数据类型</param>
        /// <returns></returns>
        public static string SqlTypeName2DotNetType(string sqlTypeString)
        {
            string[] SqlTypeNames = new string[] { "int", "varchar","bit" ,"datetime","decimal","float","image","money",
                "ntext","nvarchar","smalldatetime","smallint","text","bigint","binary","char","nchar","numeric",
                "real","smallmoney", "sql_variant","timestamp","tinyint","uniqueidentifier","varbinary"};

            string[] DotNetTypes = new string[] {"int", "string","bool" ,"DateTime","Decimal","Double","Byte[]","Single",
                "string","string","DateTime","Int16","string","Int64","Byte[]","string","string","Decimal",
                "Single","Single", "Object","Byte[]","Byte","Guid","Byte[]"};

            int i = Array.IndexOf(SqlTypeNames, sqlTypeString.ToLower());

            return DotNetTypes[i];
        }
    }
}
