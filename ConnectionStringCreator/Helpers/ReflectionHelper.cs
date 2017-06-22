using System;
using System.Linq.Expressions;

namespace ConnectionStringCreator.Helpers
{
    internal static class ReflectionHelper
    {
        public static MemberExpression GetMemberExpression<T>(Expression<Func<T, object>> expression)
        {
            var member = expression.Body as MemberExpression;
            var unary = expression.Body as UnaryExpression;
            return member ?? (unary != null ? unary.Operand as MemberExpression : null);
        }

        public static string GetMemberName<T>(Expression<Func<T, object>> expression)
        {
            var member = expression.Body as MemberExpression;
            var unary = expression.Body as UnaryExpression;
            return (member!=null)?GetMemberName(member): (unary != null ? GetMemberName(unary.Operand as MemberExpression) : string.Empty);
        }

        public static string GetMemberName(MemberExpression memberExpression)
        {
            return (memberExpression != null) ? memberExpression.Member.Name : string.Empty;
        }


        public static object GetPropertyValue<T>(T src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null); 
        }

        public static string GetPropertyStringValue<T>(T src, MemberExpression memberExpression)
        {
            var propertyValue = GetPropertyValue(src, GetMemberName(memberExpression));
            return propertyValue != null ? propertyValue.ToString() : string.Empty;
        }

      
    }
}
