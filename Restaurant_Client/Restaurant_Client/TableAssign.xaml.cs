using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Restaurant_Client.Models;
using System.Text.RegularExpressions;

namespace Restaurant_Client
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TableAssign : ContentPage
    {
        public TableAssign()
        {
            InitializeComponent();
            Shell.SetTabBarIsVisible(this, false);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasNavigationBar(this, false);
            Shell.SetTabBarIsVisible(this, false);
            Shell.SetNavBarIsVisible(this, false);
            //Console.WriteLine(App.UserID.ToString());
        }
        async void CautaMese(object sender, EventArgs e)
        {
            List<Masa> M = await App.Database.GetMeseAsync();
            List<Masa> Copie = new List<Masa>();
            int nr = Int32.Parse(nrPers.Text);
            int min = 100;
            foreach (Masa m in M)
            {
                if (m.Nr_pers >= nr && m.Nr_pers < min && m.Dispo == true)
                    min = m.Nr_pers;
            }
            //Console.WriteLine(min.ToString());
            if (min == 100)
                await DisplayAlert("Ne pare rău! Nu s-a găsit nicio masă", "Contactacți cel mai apropiat membru al personalului pentru remedierea problemei", "OK");
            else
            {
                foreach (Masa m in M)
                {
                    if (m.Nr_pers == min && m.Dispo == true)
                        Copie.Add(m);
                }
                listaMese.ItemsSource = null;
                listaMese.ItemsSource = Copie;
                select.IsVisible = true;
                listaMese.IsVisible = true;
            }
        }
        async void OnTableSelected(object sender, SelectedItemChangedEventArgs e)
        {

            Masa m = (Masa)e.SelectedItem;
            Console.WriteLine(m.ID);
            Console.WriteLine(App.UserID.ToString());
            Comanda c = new Comanda();
            c.ID_Masa = m.ID;
            c.Suma = 0;
            c.ID_CLI = App.UserID;
            string s = await App.Database.SaveCOMANDAAsync(c);
            string nr = new string(s.Reverse().ToArray());
            Regex re = new Regex(@"\d+");
            var id = re.Match(nr);
            string id2 = new string(id.ToString().Reverse().ToArray());
            int id3 = Int32.Parse(id2);
            App.ComandaID = id3;
            Console.WriteLine(App.ComandaID.ToString());
            m.Dispo = false;
            await App.Database.SaveTable(m);
            await Navigation.PushAsync(new Meniu());
            Navigation.RemovePage(this);

        }
    }
}