using System.Collections.Generic;

namespace Countdown.Core.Numbers.Extensions
{
    public static class ArrayExtensions
    {
        public static IEnumerable<T[]> GetPairs<T>(this T[] items)
        {
            for (var i = 0; i < items.Length; i++)
            {
                for (var j = i + 1; j < items.Length; j++)
                {
                    yield return new T[]
                    {
                        items[i],
                        items[j]
                    };
                }
            }
        }
    }
}
