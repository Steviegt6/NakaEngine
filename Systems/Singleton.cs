using System;
using System.Collections.Concurrent;

namespace NakaEngine.Systems
{
    public static class Singleton
    {
        internal static ConcurrentDictionary<Type, SingletonEntry> Singletons = new();

        public static T GetValue<T>() => Singleton<T>.Value;

        public static void Add(object singleton) 
        {
            if (Singletons.TryGetValue(singleton.GetType(), out var entry)) 
            { 
                entry.Value = singleton;
                entry.Update();
            }
            else 
            {
                Singletons[singleton.GetType()] = new SingletonEntry(singleton, null);
            }
        }

        internal static void Link(Type forType, Action<object> updater) 
        {
            if (Singletons.TryGetValue(forType, out var entry)) 
            {
                entry.Updater = updater;
                entry.Update();
            } 
            else 
            {
                Singletons[forType] = new SingletonEntry(null, updater);
            }
        }

        internal static void Clear()
        {
            foreach (SingletonEntry singletonEntry in Singletons.Values)
            {
                singletonEntry.Value = null;
                singletonEntry.Update();
            }
        }

        internal class SingletonEntry
        {
            internal object Value;
            internal object SyncRoot = new();

            internal Action<object> Updater;

            public SingletonEntry(object value, Action<object> updater) 
            { 
                lock (SyncRoot) 
                {
                    Value = value;
                    Updater = updater;
                } 
            }

            internal void Update()
            {
                lock (SyncRoot) 
                {
                    Updater?.Invoke(Value);
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
