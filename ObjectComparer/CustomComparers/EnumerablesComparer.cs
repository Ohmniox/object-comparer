using ObjectComparer.Extensions;
using ObjectComparer.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer.CustomComparers
{
    internal class EnumerablesComparer : ICustomComparer
    {
        public bool CustomCompare(Type type, object obj1, object obj2)
        {
            if (obj1 == null && obj2 == null)
            {
                return true;
            }
            if ((obj1 == null && obj2 != null) || (obj1 != null && obj2 == null))
            {
                return false;
            }

            obj1 = obj1 ?? Enumerable.Empty<object>();
            obj2 = obj2 ?? Enumerable.Empty<object>();

            if (!type.InheritsFrom(typeof(IEnumerable)))
            {
                throw new ArgumentException(nameof(type));
            }

            if (!obj1.GetType().InheritsFrom(typeof(IEnumerable)))
            {
                throw new ArgumentException(nameof(obj1));
            }

            if (!obj2.GetType().InheritsFrom(typeof(IEnumerable)))
            {
                throw new ArgumentException(nameof(obj2));
            }

            object[] array1, array2;
            array1 = ((IEnumerable)obj1).Cast<object>().ToArray();
            array2 = ((IEnumerable)obj2).Cast<object>().ToArray();
            if (array1.Length != array2.Length)
            {
                return false;
            }
            if (array1.Length >= 1)
            {
                if (array1[0].GetType().IsPrimitive)
                {
                    array1 = ((IEnumerable)obj1).Cast<object>().ToArray().OrderBy(x => x).ToArray();
                    array2 = ((IEnumerable)obj2).Cast<object>().ToArray().OrderBy(x => x).ToArray();
                }
            }

            for (var i = 0; i < array2.Length; i++)
            {
                if (array1[i] == null && array2[i] == null)
                {
                    continue;
                }

                if ((array1[i] == null && array2[i] != null) || (array1[i] != null  && array2[i] == null))
                {
                    return false;
                }
                var array1ItemType = array1[i].GetType();
                if (array1ItemType != array2[i].GetType())
                {
                    return false;
                }

                var comparer = Factory.GetComparer(array1ItemType);
                if (!comparer.CustomCompare(array1ItemType, array1[i], array2[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
