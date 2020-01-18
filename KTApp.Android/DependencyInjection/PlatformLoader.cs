using Autofac;
using KTApp.Core.Options;
using KTApp.Droid.Helpers;

namespace KTApp.Droid.DependencyInjection
{
    public static class PlatformLoader
    {
        public static bool _isInitialized;

        public static void Initialize(ContainerBuilder containerBuilder)
        {
            if (_isInitialized)
            {
                return;
            }

            _isInitialized = true;

            var dbPath = FileAccessHelper.GetLocalFilePath("UKTA.db");
            containerBuilder.Register(x => new DbOptions { DbPath = dbPath }).SingleInstance();
        }
    }
}