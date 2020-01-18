using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace KTApp.Presentation.DependencyInjection
{
    public static class AppContainer
    {
        public static IContainer Container { get; set; }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }
    }
}
