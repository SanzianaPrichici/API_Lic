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
    public partial class ListaFeluri : ContentPage
    {
        public ListaFeluri()
        {
            InitializeComponent();
        }
        async void OnShopListAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddFel
            {
                BindingContext = new Fel_m()
            });
        }
    }
}