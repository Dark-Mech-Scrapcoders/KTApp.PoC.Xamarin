using Autofac;
using KTApp.Core;
using KTApp.Core.Services;
using KTApp.Models;
using KTApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace KTApp.Presentation.DependencyInjection
{
    public static class Registration
    {
        private static bool _isInitialized;

        public static void Initialize(ContainerBuilder containerBuilder)
        {
            if (_isInitialized)
            {
                return;
            }

            containerBuilder.RegisterType<KillTeamContext>().InstancePerDependency();
            containerBuilder.RegisterType<PoCService>().SingleInstance();

            containerBuilder.RegisterType<MockDataStore>()
                .As<IDataStore<Item>>()
                .SingleInstance();

            _isInitialized = true;
        }
    }
}
