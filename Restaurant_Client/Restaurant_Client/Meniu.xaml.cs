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
            carouselView.ItemsSource = await App.Database.GetProduseAsync();
        }
    }
}