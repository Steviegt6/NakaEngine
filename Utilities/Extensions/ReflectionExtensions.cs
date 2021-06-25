#nullable enable
using System;
using System.Linq;
using System.Reflection;

namespace NakaEngine.Utilities.Extensions
{
    public static class ReflectionExtensions
    {
        public static bool HasInterface(this Type type, Type interfaceType) => type.GetInterfaces().Contains(interfaceType);

        public static bool HasInterface<T>(this Type type) where T : class => type.GetInterfaces().Contains(typeof(T));

        public static bool HasEmptyConstructor(this Type type) => type.GetConstructor(Type.EmptyTypes) != null;

        public static bool HasEmptyConstructor(this Type type, out ConstructorInfo? constructor) => (constructor = type.GetConstructor(Type.EmptyTypes)) != null;

        public static bool HasAttribute<T>(this Type type) where T : Attribute => type.GetCustomAttribute<T>() != null;

        public static bool HasAttribute<T>(this Type type, out T? attribute) where T : Attribute => (attribute = type.GetCustomAttribute<T>()) != null;

        public static T CreateDelegate<T>(this MethodInfo method) where T : Delegate => (T)Delegate.CreateDelegate(typeof(T), method);

        public static T CreateDelegate<T>(this MethodInfo method, object? firstArg = null) where T : Delegate => (T)Delegate.CreateDelegate(typeof(T), firstArg, method);      

        public static MethodInfo? GetMethod(this Type type, string name, BindingFlags flags, Type[] types) => type.GetMethod(name, flags, null, types, null);

        public static ConstructorInfo? GetConstructor(this Type type, BindingFlags flags, Type[] types) => type.GetConstructor(flags, null, types, null);
    } 
}
