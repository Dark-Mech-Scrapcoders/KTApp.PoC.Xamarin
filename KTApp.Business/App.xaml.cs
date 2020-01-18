﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using KTApp.Services;
using KTApp.Views;
using KTApp.Core.Services;
using KTApp.Core;
using Autofac;

namespace KTApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // DependencyService.Register<MockDataStore>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
