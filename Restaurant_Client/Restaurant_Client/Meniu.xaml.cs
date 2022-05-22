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
            Console.Write(@"Primul pas pe pagina");
            carouselView.ItemsSource = await App.Database.GetFeluriAsync();
        }
        async void SortareMeniupret(object sender, EventArgs e)
        {
            List<Fel_m> L = (List<Fel_m>)carouselView.ItemsSource;
            List<Fel_m> SortedList = L.OrderBy(o => o.Durata).ToList();
        }
    }
}