using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Restaurant_Client.Data;

namespace Restaurant_Client
{
    public partial class App : Application
    {
        public static bool IsUserLoggedIn { get; set; }
        public static LicentaDB Database { get; private set; }
        public App()
        {
            InitializeComponent();
            Database = new LicentaDB(new RestService());
            if (!IsUserLoggedIn)
            {
                MainPage = new TableAssign();
            }
            else
            {
                MainPage = new TableAssign();
            }
            //MainPage = new NavigationPage(new Login());
            //MainPage = new AddFel();
            //MainPage = new AddProdus(); 
            //MainPage = new Meniu();
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
