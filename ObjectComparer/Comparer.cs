using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    public static class Comparer
    {
        public static bool AreSimilar<T>(T first, T second )
        {
            /// Add your implementation logic here. Feel free to add classes and types as required for your solution.
            var baseComparer = new BaseComparer<T>();
            return baseComparer.CustomCompare(first, second);
        }
    }
}
