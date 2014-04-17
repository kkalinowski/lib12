using System;

namespace lib12.DependencyInjection
{
    public static class Instances
    {
        #region Props
        public static InstancesContainer Container { get; set; }
        #endregion

        #region sctor
        static Instances()
        {
            Container = new InstancesContainer();
        }

        #endregion

        #region Get
        public static T Get<T>()
        {
            return Container.Get<T>();
        }

        public static object Get(Type type)
        {
            return Container.Get(type);
        }

        public static object Get(string key)
        {
            return Container.Get(key);
        }
        #endregion

        #region Register
        public static void RegisterSingleton<T>(string key = null)
        {
            Container.RegisterSingleton<T>(key);
        }

        public static void RegisterSingleton<TContract, TService>(string key = null)
        {
            Container.RegisterSingleton<TContract, TService>(key);
        }

        public static void RegisterTransient<T>(string key = null)
        {
            Container.RegisterTransient<T>(key);
        }

        public static void RegisterTransient<TContract, TService>(string key = null)
        {
            Container.RegisterTransient<TContract, TService>(key);
        }
        #endregion
    }
}
