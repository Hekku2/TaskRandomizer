using System;
using System.Collections.Generic;
using System.Linq;

namespace Randomizer
{
    public class ListRandomizer
    {
        public static List<T> Suffle<T>(IList<T> list)
        {
            var rnd = new Random();
            return list.OrderBy(item => rnd.Next()).ToList();
        }
    }
}
