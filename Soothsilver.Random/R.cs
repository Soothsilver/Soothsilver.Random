using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RD = System.Random;

namespace Soothsilver.Random
{
    /// <summary>
    /// Contains static methods that produce random results.
    /// </summary>
    public static class R
    {
        private static RD rgen = new RD();

        /// <summary>
        /// Returns a random integer between <paramref name="minimumInclusive"/> (inclusive) and <paramref name="maximumExclusive"/> (exclusive).
        /// </summary>
        /// <param name="minimumInclusive">The minimum integer (inclusive, this may be returned).</param>
        /// <param name="maximumExclusive">The maximum integer (exclusive, this cannot be returned).</param>
        public static int Next(int minimumInclusive, int maximumExclusive)
        {
            return rgen.Next(minimumInclusive, maximumExclusive);
        }

        /// <summary>
        /// Returns a random integer between 0 (inclusive) and <paramref name="maximumExclusive"/> (exclusive).
        /// </summary>
        /// <param name="maximumExclusive">The maximum integer (exclusive, this cannot be returned).</param>
        public static int Next(int maximumExclusive)
        {
            return rgen.Next(maximumExclusive);
        }

        /// <summary>
        /// Returns a random double between 0.0 and 1.0.
        /// </summary>
        public static double NextDouble()
        {
            return rgen.NextDouble();
        } 

        /// <summary>
        /// Returns a random double between <paramref name="minimum"/> and <paramref name="maximum"/>.
        /// </summary>
        /// <param name="minimum">The minimum number that may be returned.</param>
        /// <param name="maximum">The maximum number that may be returned.</param>
        public static double NextDouble(double minimum, double maximum)
        {
            double interval = maximum - minimum;
            return minimum + rgen.NextDouble() * interval;
        }

        /// <summary>
        /// Returns a random float between 0.0 and 1.0.
        /// </summary>
        public static float NextFloat()
        {
            return (float)rgen.NextDouble();
        }

        /// <summary>
        /// Returns a random float between <paramref name="minimum"/> and <paramref name="maximum"/>.
        /// </summary>
        /// <param name="minimum">The minimum number that may be returned.</param>
        /// <param name="maximum">The maximum number that may be returned.</param>
        public static float NextFloat(float minimum, float maximum)
        {
            return (float)NextDouble(minimum, maximum);
        }

        /// <summary>
        /// Flips a fair coin. If it falls heads, returns true; otherwise returns false.
        /// </summary>
        public static bool Coin()
        {
            return Next(0,2) == 0;
        }

        /// <summary>
        /// Rolls a 100-sided die. If a number comes up that's less than or equal to <paramref name="percentChance"/>, returns true; otherwise returns false.
        /// </summary>
        /// <param name="percentChance">The chance of returning true; e.g. "20" means a 20% chance.</param>
        /// <returns></returns>
        public static bool PercentChance(int percentChance)
        {
            return Next(1, 101) <= percentChance;
        }

        /// <summary>
        /// Randomizes the list so that its elements are in a random order.
        /// </summary>
        /// <typeparam name="T">Type of the list's elements.</typeparam>
        /// <param name="list">The list to shuffle.</param>
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rgen.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        /// <summary>
        /// Gets a random element of the list.
        /// </summary>
        /// <typeparam name="T">Type of the list's elements.</typeparam>
        /// <param name="list">The list to get a random element from.</param>
        public static T GetRandom<T>(this IList<T> list)
        {
            return list[rgen.Next(0, list.Count)];
        }

        /// <summary>
        /// Gets <paramref name="numElements"/> random elements from the list, without repetition - each element will appear at most once. For efficiency, use this method when the number of elements is low compared to the size of the list.
        /// </summary>
        /// <typeparam name="T">Type of the element of the list.</typeparam>
        /// <param name="list">The list to take random elements from</param>
        /// <param name="numElements">The number of random elements to return (must be less or equal to the size of the list).</param>
        public static List<T> GetRandomWithoutReplacement<T>(this IList<T> list, int numElements)
        {
            if (numElements > list.Count)
            {
                throw new InvalidOperationException("The number of elements to take must be equal to or less than the number of elements in the list.");
            }
            var result = new List<T>();
            var indices = new List<int>();
            for (int i = 0; i < numElements; i++)
            {
                int randomIndex = rgen.Next(0, list.Count);
                if (indices.Contains(randomIndex))
                {
                    i--;
                    continue;
                }
                indices.Add(randomIndex);
            }
            for (int i =0; i< numElements; i++)
            {
                result.Add(list[indices[i]]);
            }
            return result;
        }

        /// <summary>
        /// Gets <paramref name="numElements"/> random elements from the list, without repetition - each element will appear at most once. For efficiency, use this method when the number of elements is high, such as half of the list.
        /// </summary>
        /// <typeparam name="T">Type of the element of the list.</typeparam>
        /// <param name="enumerable">The list to take random elements from</param>
        /// <param name="numElements">The number of random elements to return (must be less or equal to the size of the list).</param>
        public static List<T> GetRandomWithoutReplacementStrategy2<T>(this IEnumerable<T> enumerable, int numElements)
        {
            var list = enumerable.ToList();
            if (numElements > list.Count)
            {
                throw new InvalidOperationException("The number of elements to take must be equal to or less than the number of elements in the list.");
            }

            var result = new List<T>();

            for (int i =0; i < numElements; i++)
            {
                int index = rgen.Next(0, list.Count);
                result.Add(list[index]);
                list.RemoveAt(index);
            }

            return result;
        }
    }
}
