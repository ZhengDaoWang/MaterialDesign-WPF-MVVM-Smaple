using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ZFS.Library
{
    /// <summary>
    /// 动态表达式帮助类
    /// </summary>
    public class ExpressionHelper
    {
        /// <summary>
        /// 生成表达式树
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> GenerateQueryExp<T>(T searchModel) where T : class, new()
        {
            List<MethodCallExpression> mcList = new List<MethodCallExpression>();
            Type type = searchModel.GetType();
            ParameterExpression parameterExpression = Expression.Parameter(type, "x");
            var pros = type.GetProperties();
            foreach (var t in pros)
            {
                var objValue = t.GetValue(searchModel, null);
                if (objValue != null && t.Name != "isid")
                {
                    Expression proerty = Expression.Property(parameterExpression, t);
                    ConstantExpression constantExpression = Expression.Constant(objValue, t.PropertyType);
                    if (t.PropertyType.Name != "Int32")
                        mcList.Add(Expression.Call(proerty, typeof(string).GetMethod("Contains"), new Expression[] { constantExpression }));
                }
            }

            if (mcList.Count == 0)
                return Expression.Lambda<Func<T, bool>>(Expression.Constant(true, typeof(bool)), new ParameterExpression[] { parameterExpression });
            else
                return Expression.Lambda<Func<T, bool>>(MethodCall(mcList), new ParameterExpression[] { parameterExpression });
        }

        public static Expression MethodCall<T>(List<T> mcList) where T : MethodCallExpression
        {
            if (mcList.Count == 1) return mcList[0];
            BinaryExpression binaryExpression = null;
            for (int i = 0; i < mcList.Count; i += 2)
            {
                if (i < mcList.Count - 1)
                {
                    BinaryExpression binary = Expression.OrElse(mcList[i], mcList[i + 1]);
                    if (binaryExpression != null)
                        binaryExpression = Expression.OrElse(binaryExpression, binary);
                    else
                        binaryExpression = binary;
                }
            }
            if (mcList.Count % 2 != 0)
                return Expression.OrElse(binaryExpression, mcList[mcList.Count - 1]);
            else
                return binaryExpression;
        }
    }
}
