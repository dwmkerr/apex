using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apex.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Flattens a hierarchial data structure.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source collection.</param>
        /// <param name="getChildrenFunction">The get children function, e.g. for a tree node this would be (node) => node.Children .</param>
        /// <returns>The hierarchy as a flat list.</returns>
        public static IEnumerable<TSource> Flatten<TSource>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TSource>> getChildrenFunction)
        {
            //  Create a flat list.
            var flattenedList = new List<TSource>();

            //  Go through each item...
            foreach (var item in source)
            {
                //  Add it, then concatenate the children.
                flattenedList.Add(item);
                flattenedList = flattenedList.Concat(getChildrenFunction(item).Flatten(getChildrenFunction)).ToList();
            }

            //  Return the flattened list.
            return flattenedList;
        }
    }
}
