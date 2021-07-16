using System;
using System.Linq;
using System.Reflection;

namespace NakaEngine.Utilities.Extensions
{
    public static class ReflectionExtensions 
    {
        public static Type[] GetTypesWithInterface<T>(this Assembly assembly) where T : class => assembly.GetTypes().Where(type => type.GetInterfaces().Contains(typeof(T))).ToArray();

        public static Type[] GetTypesWithType<T>(this Assembly assembly) where T : class => assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(T))).ToArray();
    }
}
