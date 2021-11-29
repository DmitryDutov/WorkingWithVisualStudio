using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace TestPrj
{
    public class Comparer
    {
        public static Comparer<U> Get<U>(Func<U,U,bool> func)
        {
            return new Comparer<U>(func);
        }
    }

    public class Comparer<T>: Comparer, IEqualityComparer<T>
    {
        private Func<T, T, bool> commparisonFunction;
        public Comparer(Func<T, T, bool> func)
        {
            commparisonFunction = func;
        }

        public bool Equals(T x, T y)
        {
            return commparisonFunction(x, y);
        }

        public int GetHashCode(T obj)
        {
            return obj.GetHashCode();
        }
    }
}

