using NakaEngine.Interfaces;
using NakaEngine.Utilities.Extensions;
using System;
using System.Collections.Generic;

namespace NakaEngine.Loaders
{
    public static class LoadableLoader
    {
        private static List<ILoadable> LoadCache
        {
            get;
            set;
        } = new();

        public static void Load()
        {
            foreach (Type type in NakaEngine.Assembly.GetTypes())
            {
                if (!type.IsAbstract && type.HasInterface<ILoadable>())
                {
                    ILoadable loadable = Activator.CreateInstance(type) as ILoadable;
                    loadable.Load();

                    LoadCache.Add(loadable);
                }
            }
        }

        public static void Unload()
        {
            foreach (ILoadable loadable in LoadCache)
            {
                loadable.Unload();
            }

            LoadCache.Clear();
        }
    }
}
