using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apex.Extensions
{
  /// <summary>
  /// A set of useful extensions for the List interface.
  /// </summary>
    public static class ListExtensions
    {
      /// <summary>
      /// Some of these functions need random numbers - so keep a single
      /// Random instance.
      /// </summary>
      private static Random rng = new Random();

      /// <summary>
      /// Shuffles the specified list.
      /// </summary>
      /// <typeparam name="T">The list type.</typeparam>
      /// <param name="list">The list.</param>
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        /// <summary>
        /// Returns a random element from the list.
        /// </summary>
        /// <typeparam name="T">The list type.</typeparam>
        /// <param name="list">The list.</param>
        /// <returns>A random element from the list.</returns>
        public static T RandomElement<T>(this IList<T> list)
        {
          return list.ElementAt(rng.Next(0, list.Count));
        }
    }
}
