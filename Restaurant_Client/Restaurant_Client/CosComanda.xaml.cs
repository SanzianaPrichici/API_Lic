using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurant_Client
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CosComanda : ContentPage
    {
        public CosComanda()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetCos(App.ComandaID);
            await Navigation.PopModalAsync();
        }
    }
}