namespace IEH_Dashboard.Utility
{
    using System;
    using System.Threading;

    /// <summary>
    /// Defines the <see cref="DbClientFactory{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DbClientFactory<T>
    {
        /// <summary>
        /// Defines the _factoryLazy
        /// </summary>
        private static Lazy<T> _factoryLazy = new Lazy<T>(
         () => (T)Activator.CreateInstance(typeof(T)),
         LazyThreadSafetyMode.ExecutionAndPublication);

        /// <summary>
        /// Gets the Instance
        /// </summary>
        public static T Instance
        {
            get
            {
                return _factoryLazy.Value;
            }
        }
    }
}
