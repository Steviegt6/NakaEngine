using System.Collections.Generic;
using System.Linq;

namespace NakaEngine.Core
{
    public static class SingletonManager
    {
        private static readonly List<object> singletons = new();

        public static void Register(object instance)
        {
            if (!singletons.Contains(instance))
            {
                singletons.Add(instance);
            }
        }

        public static T GetSingleton<T>() where T : class => singletons.FirstOrDefault(singleton => singleton is T) as T;
    }
}
