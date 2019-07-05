using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.Library
{
    /// <summary>
    /// 对象深拷贝 -反射
    /// </summary>
    public static class ClassOperation
    {
        public static T CopyByReflect<T>(T obj)
        {
            object retval = Activator.CreateInstance(obj.GetType());
            PropertyInfo[] fields = obj.GetType().GetProperties();
            foreach (var field in fields)
            {
                try { field.SetValue(retval, field.GetValue(obj)); }
                catch { }
            }
            return (T)retval;
        }
        
    }
}
