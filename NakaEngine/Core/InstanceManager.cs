using System;
using System.Collections.Concurrent;

namespace NakaEngine.Core
{
    public static class InstanceManager
    {
        private static readonly ConcurrentDictionary<Type, InstanceEntry> entries = new(); 

        internal static void Link(Type type, Action<object> update)
        {
            if (entries.TryGetValue(type, out var entry)) 
            {
                entry.Update = update; 
                update(entry.Value); 

                return;
            } 
            
            entries[type] = new(null, update);           
        }

        public static void Register(object instance)
        {
            if (entries.TryGetValue(instance.GetType(), out InstanceEntry entry))
            {
                if (entry.HasValue)
                {
                    return;
                }

                entry.Value = instance; 
                entry.Update?.Invoke(instance);

                return;
            }

            entries[instance.GetType()] = new InstanceEntry(instance, null); 
        }

        public static T GetInstance<T>() where T : class => InstanceManager<T>.Instance;

        public class InstanceEntry
        {
            public Action<object> Update;

            public object Value;

            public bool HasValue => Value != null;

            public InstanceEntry(object value, Action<object> update)
            {
                Value = value;
                Update = update;
            }
        }
    } 

    public static class InstanceManager<T>
    {
        public static T Instance { get; private set; }

        static InstanceManager() => InstanceManager.Link(typeof(T), Update); 

        private static void Update(object instance) => Instance = (T)instance;

        internal static void Update(T instance) => Instance = instance;
    } 
}
