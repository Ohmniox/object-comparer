using ObjectComparer.CustomComparers;
using ObjectComparer.Extensions;
using ObjectComparer.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    public class BaseComparer<T> : ICustomComparer<T>
    {
        public bool CustomCompare(T obj1, T obj2)
        {
            var _members = typeof(T).GetAllProperties(new List<Type>());
            if (obj1 == null && obj2 == null)
            {
                return true;
            }
            if ((obj1 == null && obj2 != null) || (obj1 != null && obj2 == null))
            {
                return false;
            }
            if (typeof(T).IsPrimitive || typeof(T).InheritsFrom(typeof(IComparable)))
            {
                var comparer = Factory.GetComparer(typeof(T));
                return comparer.CustomCompare(typeof(T), obj1, obj2);
            }

            foreach (var member in _members)
            {
                var value1 = member.GetValue(obj1);
                var value2 = member.GetValue(obj2);
                var type = member.PropertyType;

                var objectDataComparer = Factory.GetComparer(type);
                if (!objectDataComparer.CustomCompare(type, value1, value2))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
