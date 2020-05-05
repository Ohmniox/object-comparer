using ObjectComparer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer.CustomComparers
{
    public class StringComparer : ICustomComparer
    {
        public  bool CustomCompare(Type type, object obj1, object obj2)
        {
            if (obj1 == null && obj2 == null)
            {
                return true;
            }

            if ((obj1 == null && obj2 != null) || (obj1 != null && obj2 == null))
            {
                return false;
            }
            var str1 = (string)obj1;
            var str2 = (string)obj2;

            return str1.Equals(str2);
        }
    }
}
