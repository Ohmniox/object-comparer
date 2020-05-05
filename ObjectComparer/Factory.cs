using ObjectComparer.CustomComparers;
using ObjectComparer.Extensions;
using ObjectComparer.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringComparer = ObjectComparer.CustomComparers.StringComparer;

namespace ObjectComparer
{
    public class Factory
    {
        public static ICustomComparer GetComparer(Type type)
        {
            if (type.InheritsFrom(typeof(string)))
            {
                return new StringComparer();
            }
            else if (type.InheritsFrom(typeof(IEnumerable)))
            {
                return new EnumerablesComparer();
            }
            else
            {
                return new DefaultComparer();
            }
        }
    }
}
