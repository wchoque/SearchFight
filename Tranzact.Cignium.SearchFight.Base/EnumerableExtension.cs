﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tranzact.Cignium.SearchFight.Base
{
    public static class EnumerableExtension
    {
        public static T GetMax<T>(this IEnumerable<T> source, Func<T, long> func)
        {
            if (source == null)
                throw new ArgumentException("The specified parameter cannot be null.", nameof(source));

            using (var enumerator = source.GetEnumerator())
            {
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
}
