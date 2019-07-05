using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.Library.Generator
{
    public class GeneratorToModelClass : IGeneratorToClass
    {
        public string Create(string nameSpace, string desc, string className, string body)
        {
            StringBuilder builder = new StringBuilder();
            this.CreateAnnotation(builder, className, desc);
            builder.Append("using System;\r\n");
            builder.Append("using System.ComponentModel.DataAnnotations;\r\n");
            builder.Append("namespace " + nameSpace + "\r\n");
            builder.Append("{\r\n");
            builder.Append(body);
            builder.Append("}\r\n");
            return builder.ToString();
        }

        /// <summary>
        /// 生成注释部分
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="concretelyName"></param>
        private void CreateAnnotation(StringBuilder builder, string ClassName, string Desc)
        {
            builder.AppendLine("");
            builder.AppendLine("/*—————————————————————————————");
            builder.AppendLine(" *   程序说明: " + Desc);
            builder.AppendLine(" *   作者姓名: Design by ZFS.");
            builder.AppendLine(" *   创建日期: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"));
            builder.AppendLine(" *   最后修改: " + DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"));
            builder.AppendLine(" *   ");
            builder.AppendLine(" *   注: 本代码由ZFS.Generator自动生成");
            builder.AppendLine(" *—————————————————————————————*/");
            builder.AppendLine("");
        }
    }
}
