using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppEsqueci.Views;

namespace AppEsqueci
{
    public partial class App : Application
    {
        public static string DbName;
        public static string DbPath;

        public App()
        {
            InitializeComponent();

            MainPage = new PagePrincipal();
        }

        public App(string dbPath, string dbName)
        {
            InitializeComponent();
            App.DbName = dbName;
            App.DbPath = dbPath;
            MainPage = new PagePrincipal();
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
