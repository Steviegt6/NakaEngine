using System;
using System.Linq;
using System.Reflection;

namespace NakaEngine.Utilities.Extensions
{
    public static class ReflectionExtensions
    {
        /// <summary>
        /// Returns an array of all types in an <see cref="Assembly"/> inherited by a <see cref="Type"/>
        /// </summary>
        public static Type[] GetInheritedTypes(this Assembly assembly, Type inheritedType) => assembly.GetTypes().Where(type => !type.IsAbstract && type.IsSubclassOf(inheritedType)).ToArray();

        /// <summary>
        /// Returns an array of all types in an <see cref="Assembly"/> inherited by the type <paramref name="T"/>.
        /// </summary>
        public static Type[] GetInheritedTypes<T>(this Assembly assembly) where T : class => assembly.GetInheritedTypes(typeof(T));

        /// <summary>
        /// Returns an array of all types in an <see cref="Assembly"/> inherited by an interface with type.
        /// </summary>
        public static Type[] GetInheritedInterfaceTypes(this Assembly assembly, Type interfaceType) => assembly.GetTypes().Where(type => !type.IsAbstract && type.GetInterfaces().Contains(interfaceType)).ToArray();

        /// <summary>
        /// Returns an array of all types in an <see cref="Assembly"/> inherited by an interface with type <typeparamref name="T"/>
        /// </summary>
        public static Type[] GetInheritedInterfaceTypes<T>(this Assembly assembly) where T : class => assembly.GetInheritedInterfaceTypes(typeof(T));

        /// <summary>
        /// Returns whether a <see cref="Type"/> inherits from an interface with type or not.
        /// </summary>
        public static bool HasInterface(this Type type, Type interfaceType) => type.GetInterfaces().Contains(interfaceType);

        /// <summary>
        /// Returns whether a <see cref="Type"/> inherits from an interface with type or not.
        /// </summary>
        public static bool HasInterface<T>(this Type type) where T : class => type.HasInterface(typeof(T));

        /// <summary>
        /// Returns whether a <see cref="Type"/> has an empty constructor or not.
        /// </summary>
        public static bool HasEmptyConstructor(this Type type) => type.GetConstructor(Type.EmptyTypes) != null;
    } 
}
