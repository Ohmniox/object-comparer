using ObjectComparer.CustomComparers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer.Interfaces
{
    public interface ICustomComparer 
    {
        bool CustomCompare(Type type, object obj1, object obj2);
    }

    public interface ICustomComparer<in T>  
    {
        bool CustomCompare(T obj1, T obj2);
    }
}
