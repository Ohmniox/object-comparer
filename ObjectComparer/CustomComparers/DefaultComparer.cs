using ObjectComparer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer.CustomComparers
{
    public class DefaultComparer : ICustomComparer
    {
        public  bool CustomCompare(Type type, object obj1, object obj2)
        {
            if (obj1 == null || obj2 == null)
            {
                return obj1 == obj2;
            }

            return obj1.Equals(obj2);
        }
    }
}
