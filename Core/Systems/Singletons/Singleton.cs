using System;
using System.Collections.Concurrent;

namespace NakaEngine.Core.Systems.Singletons
{
    /*==============================================================================================================
    *  - Singleton<T> holds the singleton, when tried to be acessed it will 'link' to Singleton which has all 
    *  instances
    *   
    * - When an object is added on Singleton, the respective Singleton<T> would update it's instance if it's linked
    *
    * - If a singleton is registered on Singleton and the Singleton<T> hasn't linked, Singleton<T> will update it's 
    * value when it links
    ==============================================================================================================*/

    public static class Singleton
    {
        internal static ConcurrentDictionary<Type, SingletonEntry> Singletons = new();

        public static void Add(object singleton) 
        {
            if (Singletons.TryGetValue(singleton.GetType(), out var entry)) // When static class linked.
            { 
                entry.value = singleton;
                entry.Update();
            }
            else // When class isn't linked.
            {
                Singletons[singleton.GetType()] = new SingletonEntry(singleton, null);
            }
        }

        public static T Get<T>() => Singleton<T>.Value;

        internal static void Link(Type forType, Action<object> updater) 
        {
            if (Singletons.TryGetValue(forType, out var entry)) // Singleton already exists.
            {
                entry.updater = updater;
                entry.Update();
            } 
            else // Singleton doesn't exist yet.
            {
                Singletons[forType] = new SingletonEntry(null, updater);
            }
        }

        internal static void Clear() // Dictionary is not cleared because static constructors only run once, so a Singleton<T> can only link once.
        {
            foreach (SingletonEntry singletonEntry in Singletons.Values)
            {
                singletonEntry.value = null;
                singletonEntry.Update();
            }
        }

        internal class SingletonEntry
        {
            internal object value;
            internal object syncRoot = new();

            internal Action<object> updater;

            public SingletonEntry(object value, Action<object> updater) 
            { 
                lock (syncRoot) 
                {
                    this.value = value;
                    this.updater = updater;
                } 
            }

            internal void Update()
            {
                lock (syncRoot) 
                {
                    updater?.Invoke(value);
                }
            }
        }
    }

    public static class Singleton<T>
    {
        public static T Value
        {
            get;
            private set;
        }

        static Singleton() => Singleton.Link(typeof(T), Update);

        private static void Update(object singletonInstance) => Value = (T)singletonInstance;
    }
}
