using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Restaurant_Client.Data;

namespace Restaurant_Client
{
    public partial class App : Application
    {
        public static LicentaDB Database { get; private set; }
        public App()
        {
            InitializeComponent();

            Database = new LicentaDB(new RestService());
            //MainPage = new NavigationPage(new Login());
            MainPage = new AddFel();
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
