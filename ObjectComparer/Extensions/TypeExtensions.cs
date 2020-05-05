using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer.Extensions
{
    internal static class TypeExtensions
    {
        public static bool InheritsFrom(this Type t1, Type t2)
        {
            if (null == t1 || null == t2)
            {
                return false;
            }

            if (t1 == t2)
            {
                return true;
            }

            if (t1.GetTypeInfo().IsGenericType && t1.GetTypeInfo().GetGenericTypeDefinition() == t2)
            {
                return true;
            }

            if (t1.GetTypeInfo().GetInterfaces().Any(i => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == t2 || i == t2))
            {
                return true;
            }

            return t1.GetTypeInfo().BaseType != null &&
                   InheritsFrom(t1.GetTypeInfo().BaseType, t2);
        }

        public static List<PropertyInfo> GetAllProperties(this Type type, List<Type> processedTypes)
        {
            var properties = type.GetTypeInfo().GetProperties().Where(p =>
                p.CanRead
                && p.GetGetMethod(true).IsPublic
                && p.GetGetMethod(true).GetParameters().Length == 0
                && !p.GetGetMethod(true).IsStatic).ToList();
            processedTypes.Add(type);
            return properties;
        }
    }
}
