using System;
using System.Collections.Generic;

namespace Tranzact.Cignium.SearchFight.Base
{
    /// <summary>
    /// Extended class for IEnumarable class
    /// </summary>
    public static class EnumerableExtension
    {

        /// <summary>
        ///Gets the maximum item from an IEnumerable object depending on a lambda function
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="func"></param>
        /// <returns>Max item from source</returns>
        public static T GetMax<T>(this IEnumerable<T> source, Func<T, long> func)
        {
            if (source == null)
                throw new ArgumentException("The specified parameter cannot be null.", nameof(source));

            using var enumerator = source.GetEnumerator();
            if (!enumerator.MoveNext())
                throw new ArgumentException("Cannot get next enumerator from specified parameter.", nameof(source));

            long currentMax = func(enumerator.Current);
            T maxItem = enumerator.Current;

            while (enumerator.MoveNext())
            {
                var possible = func(enumerator.Current);

                if (currentMax < possible)
                {
                    currentMax = possible;
                    maxItem = enumerator.Current;
                }
            }
            return maxItem;
        }
    }
}
