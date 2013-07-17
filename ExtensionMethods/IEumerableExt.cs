namespace System.Collections.Generic
{
    using System;
    using System.Collections;
    using System.Linq;

    /// <summary>
    /// Small Helper Class to Group and count enumerables by criteria (Make a tree of the answers)
    /// </summary>
    public class GroupResult
    {
        /// <summary>
        /// Gets or set the <see cref="System.Object"/> used as the key for the group item.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public object Key { get; set; }

        /// <summary>
        /// Gets or set the value indicating the count of the number of items in the group.
        /// </summary>
        /// <value>
        /// The count of the items.
        /// </value>
        public int Count { get; set; }

        /// <summary>
        /// Gets or set the Enumerable holding all the items in the group
        /// </summary>
        public IEnumerable Items { get; set; }

        /// <summary>
        /// Gets or set the IEnumerable for the SubGrouped items.
        /// </summary>
        /// <value>
        /// The sub groups under this item.
        /// </value>
        public IEnumerable<GroupResult> SubGroups { get; set; }

        /// <summary>
        /// Returns a formatted <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0} ({1})", Key, Count);
        }
    }

    public static class IEumerableExt
    {
        public static T Find<T>(this IEnumerable<T> enumerable, Func<T,bool> predicate) 
        {
            foreach ( var current in enumerable ) 
            {
                if ( predicate(current) ) 
                {
                    return current;
                }
            }

            return default(T);
        }

        public static void Update<TSource>(this IEnumerable<TSource> outer, Action<TSource> updator)
        {
            foreach (var item in outer)
            {
                updator(item);
            }
        }

        public static IEnumerable<T> Intersperse<T>(this IEnumerable<T> items, T separator)
        {
            var first = true;
            foreach (var item in items)
            {
                if (first) 
                {
                    first = false;
                }
                else
                {
                    yield return separator;
                }

                yield return item;
            }
        }


        public static IEnumerable<T> Append<T>(this IEnumerable<T> elements, T element)
        {
            foreach (T t in elements)
            {
                yield return t;
            }

            yield return element;
        }

        public static IEnumerable<T> Exclude<T>(this IEnumerable<T> elements, T element)
        {
            foreach (T t in elements)
            {
                if (!t.Equals(element))
                {
                    yield return t;
                }
            }
        }

        // Select with a Where clause
        public static IEnumerable<T> WhereSelect<T>(this IEnumerable<T> elements, Predicate<T> filter)
        {
            foreach (T t in elements)
            {
                if (filter(t))
                {
                    yield return t;
                }
            }
        }

        public static IEnumerable<TResult> WhereSelect<TElement, TResult>(this IEnumerable<TElement> elements, Predicate<TElement> filter, Converter<TElement, TResult> selector)
        {
            foreach (TElement t in elements)
            {
                if (filter(t))
                {
                    yield return selector(t);
                }
            }
        }


        // Group an enumerable by more than one column
        public static IEnumerable<GroupResult> GroupByMany<TElement>(this IEnumerable<TElement> elements, params Func<TElement, object>[] groupSelectors)
        {
            if (groupSelectors.Length > 0)
            {
                var selector = groupSelectors.First();

                //reduce the list recursively until zero
                var nextSelectors = groupSelectors.Skip(1).ToArray();

                return elements.GroupBy(selector)
                            .Select(g => new GroupResult
                            {
                                Key = g.Key,
                                Count = g.Count(),
                                Items = g,
                                SubGroups = g.GroupByMany(nextSelectors)
                            });
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns all distinct elements of the given source, where "distinctness"
        /// is determined via a projection and the default eqaulity comparer for the projected type.
        /// </summary>
        /// <remarks>
        /// This operator uses deferred execution and streams the results, although
        /// a set of already-seen keys is retained. If a key is seen multiple times,
        /// only the first element with that key is returned.
        /// </remarks>
        /// <typeparam name="TSource">Type of the source sequence</typeparam>
        /// <typeparam name="TKey">Type of the projected element</typeparam>
        /// <param name="source">Source sequence</param>
        /// <param name="keySelector">Projection for determining "distinctness"</param>
        /// <returns>A sequence consisting of distinct elements from the source sequence,
        /// comparing them by the specified key projection.</returns>
        
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return source.DistinctBy(keySelector, null);
        }

        /// <summary>
        /// Returns all distinct elements of the given source, where "distinctness"
        /// is determined via a projection and the specified comparer for the projected type.
        /// </summary>
        /// <remarks>
        /// This operator uses deferred execution and streams the results, although
        /// a set of already-seen keys is retained. If a key is seen multiple times,
        /// only the first element with that key is returned.
        /// </remarks>
        /// <typeparam name="TSource">Type of the source sequence</typeparam>
        /// <typeparam name="TKey">Type of the projected element</typeparam>
        /// <param name="source">Source sequence</param>
        /// <param name="keySelector">Projection for determining "distinctness"</param>
        /// <param name="comparer">The equality comparer to use to determine whether or not keys are equal.
        /// If null, the default equality comparer for <c>TSource</c> is used.</param>
        /// <returns>A sequence consisting of distinct elements from the source sequence,
        /// comparing them by the specified key projection.</returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (keySelector == null)
            {
                throw new ArgumentNullException("keySelector");
            }

            return DistinctByImpl(source, keySelector, comparer);
        }

        private static IEnumerable<TSource> DistinctByImpl<TSource, TKey>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            return source.GroupBy(keySelector, comparer).Select(g => g.First());
        }
    }
}