using System;
using System.Linq;
using System.Reflection;

namespace NakaEngine.Utilities.Extensions
{
    public static class ReflectionExtensions
    {
        public static bool HasInterface(this Type type, Type interfaceType) => type.GetInterfaces().Contains(interfaceType);

        public static bool HasEmptyConstructor(this Type type) => type.GetConstructor(Type.EmptyTypes) != null;

        public static bool HasEmptyConstructor(this Type type, out ConstructorInfo constructor) => (constructor = type.GetConstructor(Type.EmptyTypes)) != null;

        public static bool HasAttribute<T>(this Type type) where T : Attribute => type.GetCustomAttribute<T>() != null;

        public static bool HasAttribute<T>(this Type type, out T attribute) where T : Attribute => (attribute = type.GetCustomAttribute<T>()) != null;
    } 
}
