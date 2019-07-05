using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFS.Library;
using ZFS.Library.Generator;
using ZFS.Model;
using ZFSData.InterFace;

namespace ZFSData.Manager
{

    /// <summary>
    /// 代码管理器
    /// </summary>
    public class GeneratorManager : IGenerator
    {
        /// <summary>
        /// 获取数据库表名列表
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResponse> GetUvs()
        {
            try
            {
                using (var db = new ZFSConfig())
                {
                    var task = await db.Database.SqlQuery<string>("select name from sysobjects where type " +
                        "in('U','V') order by name").ToListAsync();
                    return new ServiceResponse() { Success = true, Results = task };
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.WriteLog("获取表OR视图", ex);
                return new ServiceResponse() { Success = false, ErrorCode = ex.Message };
            }
        }

        /// <summary>
        /// 获取表结构
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public async Task<ServiceResponse> GetTableStructs(string tableName, string nameSpace, string desc)
        {
            try
            {
                using (var db = new ZFSConfig())
                {
                    var task = await db.Database.
                         SqlQuery<TableStruct>("select a.COLUMN_NAME,a.DATA_TYPE,a.CHARACTER_MAXIMUM_LENGTH,b.value AS VALUE " +
                             "from information_schema.COLUMNS as a " +
                             "left join sys.extended_properties as b " +
                             "on a.TABLE_NAME = OBJECT_NAME(b.major_id) " +
                             "and a.ORDINAL_POSITION = b.minor_id " +
                             "where a.TABLE_NAME = '" + tableName + "'").ToListAsync();

                    if (task != null)
                    {
                        var ts = task.FirstOrDefault(t => t.COLUMN_NAME.Equals("isid"));
                        if (ts != null) ts.ISPRIMARY = true;
                        IGeneratorToClass generator = new GeneratorToModelClass();
                        string cdoe = generator.Create(nameSpace, desc, tableName, CreateBody(tableName, task));

                        return new ServiceResponse() { Success = true, Results = cdoe };
                    }
                    return new ServiceResponse() { Success = false, ErrorCode = "Error." };
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.WriteLog("获取表结构", ex);
                return new ServiceResponse() { Success = false, ErrorCode = ex.Message };
            }
        }

        /// <summary>
        /// 创建模型主体
        /// </summary>
        /// <param name="structs"></param>
        /// <returns></returns>
        private string CreateBody(string tableName, List<TableStruct> structs)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("[Serializable]\r\n");
            builder.Append("public partial class " + tableName + "\r\n");
            builder.Append("{\r\n");
            builder.Append("\r\n");
            builder.Append("#region private field \r\n");
            builder.Append("\r\n");
            foreach (var t in structs)
            {
                builder.Append("private " +
                    GeneratorTools.SqlTypeName2DotNetType(t.DATA_TYPE) +
                    " _" + t.COLUMN_NAME + ";\r\n");
            }
            builder.Append("\r\n");
            builder.Append("#endregion \r\n");
            builder.Append("\r\n");
            foreach (var t in structs)
            {
                if (t.ISPRIMARY) builder.Append("[Key]\r\n");
                string COLUMN_NAME = t.COLUMN_NAME;
                string COLUMN_BODY = "{get{return " + "_" + COLUMN_NAME + ";}set{" + "_" + COLUMN_NAME + "=value;}}\r\n";
                builder.Append("public " + GeneratorTools.SqlTypeName2DotNetType(t.DATA_TYPE) + " " +
                    COLUMN_NAME + COLUMN_BODY);
                builder.Append("\r\n");
            }
            builder.Append("}\r\n");
            return builder.ToString();
        }
    }
}
