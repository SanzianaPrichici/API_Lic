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
    public partial class Meniu : ContentPage
    {
        public Meniu()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Shell.SetTabBarIsVisible(this,false);
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            Console.WriteLine(@"User logat?");
            Console.Write(App.IsUserLoggedIn.ToString());
            carouselView.ItemsSource = await App.Database.GetFeluriAsync();
            StepperValue.Text = xCant.Value.ToString();
        }
        async void SortareMeniupret(object sender, EventArgs e)
        {
            List<Fel_m> L = await App.Database.GetFeluriAsync();
            List<Fel_m> SortedList = L.OrderBy(o => o.Pret).ToList();
            carouselView.ItemsSource = null;
            carouselView.ItemsSource = SortedList;
        }
        async void SortareMeniuinstoc(object sender, EventArgs e)
        {
            List<Fel_m> L = await App.Database.GetFeluriAsync();
            List<Fel_m> SortedList = L.OrderByDescending(o => o.InStoc).ToList();
            carouselView.ItemsSource = new List<Fel_m>();
            //carouselView.CurrentItemChangedCommand=
            carouselView.ItemsSource = SortedList;
        }
         async protected void AdaugareCos(object sender, EventArgs a)
        {
            //Comanda c = await App.Database.GetComanda(App.ComandaID);
            //Console.WriteLine(c.ID_CLI.ToString());
            Fel_m f = (Fel_m)carouselView.CurrentItem;
            Rezervare r = new Rezervare()
            {   ID_Com=App.ComandaID,
                ID_Fel=f.ID,
                Cant = (int)xCant.Value
            };
            await App.Database.SaveRez(r);
            await Navigation.PushModalAsync(new CosComanda());
            //OnAppearing();
        }
        void IncreaseLabel(object sender, ValueChangedEventArgs e)
        {
            StepperValue.Text = xCant.Value.ToString();
        }
        async void OnCurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            Console.WriteLine("Se apeleaza onitemchange");
            try
            {
                //Fel_m x = (Fel_m)e.PreviousItem;
                //Console.WriteLine(x.Nume.ToString());
                Fel_m f = (Fel_m)e.CurrentItem;
                Console.WriteLine(@"s-a schimbat");
                Console.WriteLine(f.ID.ToString());
                Console.WriteLine(f.Nume);
                
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            //    
            //   Console.WriteLine(ex.StackTrace);
            //   Console.WriteLine(ex.Source);
            //   Console.WriteLine(ex.TargetSite);
            //}
            xCant.Value = 0;
            StepperValue.Text = xCant.Value.ToString();
        }
    }
}