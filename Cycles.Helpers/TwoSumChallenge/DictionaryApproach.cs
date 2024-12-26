using System.Collections.Generic;
using System;

namespace Cycles.Helpers.TwoSumChallenge
{
    #region DictionaryApproach
    public static class DictionaryApproach
    {
        #region Public : Methods
        /// <summary>
        ///    Finds two distinct numbers in the <paramref name="array"/> that add up to the given "target" => <paramref name="minuend"/> sum.<br/>
        ///    It uses a Dictionary to store numbers already seen during the iteration to achieve O(n) time complexity.
        /// </summary>
        /// <param name="array">An array of integers.</param>
        /// <param name="minuend">The target sum to find.</param>
        /// <returns>
        ///    An array of two integers representing the indices of the two numbers that add up to the target.<br/>
        ///    If no such pair exists, it returns an array [-1,-1].
        /// </returns>
        public static int[] TwoSum(int[] array, int minuend)
        {
            var valueIndices = new Dictionary<int, int>();
            for (var i = 0; i < array.Length; i++)
            {
                var subtrahend = array[i]; 
                var difference = minuend - subtrahend;
                if (valueIndices.TryGetValue(difference, out int index))
                {
                  return new int[]{index, i};
                }
                valueIndices.TryAdd(subtrahend, i);
            }
            return new int[]{-1,-1};
        }
        #endregion
    }
    #endregion
}