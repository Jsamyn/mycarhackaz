﻿using System;
using FreshMvvm;
using Mobile.HelpMe.Interfaces.Services;
using Mobile.HelpMe.PageModels;
using Mobile.HelpMe.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.HelpMe
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            FreshIOC.Container.Register<IGeolocationCalculations, GeolocationCalculations>().AsSingleton();

            var mainpage = new FreshTabbedNavigationContainer();

            mainpage.AddTab<MainPageModel>("Home", null);
            mainpage.AddTab<HelpMePageModel>("Help Me", null);
            mainpage.AddTab<HelpYouPageModel>("Help You", null);
            mainpage.AddTab<SignUpPageModel>("Sign Up", null);
            mainpage.AddTab<SignInPageModel>("Sign In", null);

            MainPage = mainpage;
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
