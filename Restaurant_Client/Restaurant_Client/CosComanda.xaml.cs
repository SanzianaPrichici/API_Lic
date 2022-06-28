using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Restaurant_Client.Models;

namespace Restaurant_Client
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CosComanda : ContentPage
    {
        public CosComanda()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetCos(App.ComandaID);
            List<Produs_cos> P = new List<Produs_cos>(await App.Database.GetCos(App.ComandaID));
            float m = 0;
            foreach (Produs_cos pr in P)
                m = m + pr.Durata;
            minute.Text = m.ToString();
        }
        void Afisarebuton(object sender, SelectedItemChangedEventArgs e)
        {
            stg.IsVisible = true;
        }
        async void Stergere(object sender, EventArgs e)
        {
            Produs_cos x = (Produs_cos)listView.SelectedItem;
            await App.Database.DeleteRezAsync(x.ID_rez);
            listView.ItemsSource = null;
            listView.ItemsSource = await App.Database.GetCos(App.ComandaID);
        }
        async private void Logout(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new Login(), this);
            await Navigation.PopAsync();
            await App.Database.DeleteComenziAsync(App.ComandaID);
            App.UserID = 0;
        }
    }
}