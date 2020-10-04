using System;
using System.Linq.Expressions;

namespace Core.Helpers
{
    public static class QueryHelper
    {
        public static Expression<Func<T, bool>> And<T>(Expression<Func<T, bool>> source, Expression<Func<T, bool>> expression) where T : class
        {
            if (source == null)
                return expression;
            var p = Expression.Parameter(typeof(T));
            return (Expression<Func<T, bool>>)Expression.Lambda(
                Expression.And(Expression.Invoke(source, p), Expression.Invoke(expression, p)), p);
        }
        public static Expression<Func<T, bool>> Or<T>(Expression<Func<T, bool>> source, Expression<Func<T, bool>> expression) where T : class
        {
            if (source == null)
                return expression;
            var p = Expression.Parameter(typeof(T));
            return (Expression<Func<T, bool>>)Expression.Lambda(
                Expression.Or(Expression.Invoke(source, p), Expression.Invoke(expression, p)), p);
        }
    }
}
