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
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasNavigationBar(this, false);
            Console.WriteLine(@"User logat?");
            Console.WriteLine(App.IsUserLoggedIn.ToString());
            carouselView.ItemsSource = await App.Database.GetFeluriAsync();
            StepperValue.Text = xCant.Value.ToString();
        }
        void SortareMeniupret(object sender, EventArgs e)
        {
            List<Fel_m> L = (List<Fel_m>)carouselView.ItemsSource;
            List<Fel_m> SortedList = L.OrderBy(o => o.Pret).ToList();
            carouselView.ItemsSource = null;
            carouselView.ItemsSource = SortedList;
        }
        void SortareMeniuinstoc(object sender, EventArgs e)
        {
            List<Fel_m> L = (List<Fel_m>)carouselView.ItemsSource;
            List<Fel_m> SortedList = L.OrderByDescending(o => o.InStoc).ToList();
            carouselView.ItemsSource = null;
            carouselView.ItemsSource = SortedList;
        }
         async protected void DetaliiFel(object sender, EventArgs a)
        {
            Fel_m f = (Fel_m)carouselView.CurrentItem;
            Console.WriteLine(@"aici");
            Console.WriteLine(f.ID.ToString());
            Console.WriteLine(xCant.Value.ToString());
            xCant.Value = 0;
            StepperValue.Text= xCant.Value.ToString();
            //Navigation.InsertPageBefore(new Prezentare_Fel() { BindingContext=f}, this);
            //await Navigation.PopAsync();
        }
        void IncreaseLabel(object sender, ValueChangedEventArgs e)
        {
            StepperValue.Text = xCant.Value.ToString();
        }
        void OnCurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            try
            {

                Fel_m f = (Fel_m)e.CurrentItem;
                Console.WriteLine(@"s-a schimbat");
                Console.WriteLine(f.ID.ToString());
                Console.WriteLine(f.Nume);
                xCant.Value = 0;
                StepperValue.Text = xCant.Value.ToString();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Data);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.TargetSite);
            }
            //Fel_m currentItem = e.CurrentItem as Fel_m;
            //carouselView.CurrentItem = currentItem;
        }
    }
}