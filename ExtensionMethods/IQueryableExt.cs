namespace System.Linq
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    using ExtensionMethods;

    /// <summary>
    /// A static helper class to hold IQuerable extension methods
    /// </summary>
    public static class IQueryableExt
    {
        /// <summary>
        /// IQueryable extension to check if there are any items present in the IQueryable (no items == empty)
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="q"></param>
        /// <returns></returns>
        public static bool IsEmpty<TEntity>(this IQueryable<TEntity> q)
        {
            return q.Count() == 0;
        }

        /// <summary>
        /// Orders a query by a property with the specified name in the specified direction, useful when you have a column 'NAME' rather than a Func
        /// equivalent to query.OrderBy(x => x.Property) or query.OrderByDescending(x => x.Property)
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="query">queryable to be sorted</param>
        /// <param name="propertyName">property to sort on</param>
        /// <param name="direction">direction to sort</param>
        /// <returns></returns>
        public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> query, string propertyName, SortDirection direction)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return query;
            }

            var type = typeof(TEntity);
            var property = type.GetProperty(propertyName);

            if (property == null)
            {
                throw new InvalidOperationException(string.Format("Could not find a property called '{0}' on type {1}", propertyName, type));
            }

            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);

            const string orderBy = "OrderBy";
            const string orderByDesc = "OrderByDescending";

            string methodToInvoke = direction == SortDirection.Ascending ? orderBy : orderByDesc;

            var orderByCall = Expression.Call(typeof(Queryable),
                methodToInvoke,
                new[] { type, property.PropertyType },
                query.Expression,
                Expression.Quote(orderByExp));

            return query.Provider.CreateQuery<TEntity>(orderByCall);
        }

        public static IQueryable<TEntity> ThenBy<TEntity>(this IQueryable<TEntity> query, string propertyName, SortDirection direction)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return query;
            }

            var type = typeof(TEntity);
            var property = type.GetProperty(propertyName);

            if (property == null)
            {
                throw new InvalidOperationException(string.Format("Could not find a property called '{0}' on type {1}", propertyName, type));
            }

            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);

            const string orderBy = "ThenBy";
            const string orderByDesc = "ThenByDescending";

            string methodToInvoke = direction == SortDirection.Ascending ? orderBy : orderByDesc;

            var orderByCall = Expression.Call(typeof(Queryable),
                methodToInvoke,
                new[] { type, property.PropertyType },
                query.Expression,
                Expression.Quote(orderByExp));

            return query.Provider.CreateQuery<TEntity>(orderByCall);
        }


        /// <summary>
        /// IQueryable expression tree extension to allow StartsWith() to be used in IQueryable string comparisons
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity to check.</typeparam>
        /// <param name="query">The LINQ query.</param>
        /// <param name="propertyName">Name of the property to be checked.</param>
        /// <param name="value">The value that the Entity must start with</param>
        /// <returns>A <see cref="System.Linq.IQueryable"/> holding the results</returns>
        public static IQueryable<TEntity> StartsWith<TEntity>(this IQueryable<TEntity> query, string propertyName, string value)
        {
            Type type = typeof(TEntity);

            ConstantExpression searchFilter = Expression.Constant(value);
            ParameterExpression parameter = Expression.Parameter(typeof(TEntity), "p");
            PropertyInfo property = type.GetProperty(propertyName);
            Expression propertyAccess = Expression.MakeMemberAccess(parameter, property);

            // What primative type supports this query extension method
            MethodInfo startsWith = typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });
            Expression operation = Expression.Call(propertyAccess, startsWith, searchFilter);

            // Use these things
            var whereExpression = Expression.Lambda(operation, parameter);
            var resultExpression = Expression.Call(typeof(Queryable), "Where", new Type[] { query.ElementType }, query.Expression, whereExpression);

            return query.Provider.CreateQuery<TEntity>(resultExpression);
        }

        /// <summary>
        /// IQueryable expression tree extension to allow EndsWith() to be used in IQueryable string comparisons
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity to check.</typeparam>
        /// <param name="query">The LINQ query.</param>
        /// <param name="propertyName">Name of the property to be checked.</param>
        /// <param name="value">The value that the Entity must end with</param>
        /// <returns>A <see cref="System.Linq.IQueryable"/> holding the results</returns>
        public static IQueryable<TEntity> EndsWith<TEntity>(this IQueryable<TEntity> query, string propertyName, string value)
        {
            Type type = typeof(TEntity);

            ConstantExpression searchFilter = Expression.Constant(value);
            ParameterExpression parameter = Expression.Parameter(typeof(TEntity), "p");
            PropertyInfo property = type.GetProperty(propertyName);
            Expression propertyAccess = Expression.MakeMemberAccess(parameter, property);

            // What primative type supports this query extension method
            MethodInfo endsWith = typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) });
            Expression operation = Expression.Call(propertyAccess, endsWith, searchFilter);

            // Use these things
            var whereExpression = Expression.Lambda(operation, parameter);
            var resultExpression = Expression.Call(typeof(Queryable), "Where", new Type[] { query.ElementType }, query.Expression, whereExpression);

            return query.Provider.CreateQuery<TEntity>(resultExpression);
        }

        public static ProjectionExpression<TSource> Project<TSource>(this IQueryable<TSource> source)
        {
            return new ProjectionExpression<TSource>(source);
        }

    }
}
