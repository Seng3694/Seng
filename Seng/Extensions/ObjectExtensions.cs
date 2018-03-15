using System;

namespace Seng.Extensions
{
    public static class ObjectExtensions
    {
        public static T To<T>(this object obj)
        {
            return (T)Convert.ChangeType(obj, typeof(T));
        }
    }
}
