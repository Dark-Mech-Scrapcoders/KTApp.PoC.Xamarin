using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace KTApp.Presentation.DependencyInjection
{
    public static class Setup
    {
        private static bool _isInitialized;

        public static void InitializeBuilder(Action<ContainerBuilder> platformSpecific)
        {
            if (_isInitialized && AppContainer.Container != null)
            {
                return;
            }

            var containerBuilder = new ContainerBuilder();

            Registration.Initialize(containerBuilder);

            platformSpecific(containerBuilder);

            AppContainer.Container = containerBuilder.Build();

            _isInitialized = true;
        }
    }
}
