using System;
using System.Collections.Generic;
using System.Linq;

namespace Korann.Utils
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<TResult> SelectOrDefault<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            return source != null ? source.Select(selector) : Enumerable.Empty<TResult>();
        }
    }
}