using Restaurant_Client.Models;
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
    public partial class Prezentare_Fel : ContentPage
    {
        public Prezentare_Fel()
        {
            InitializeComponent();
        }
        protected void AdaugareCos(object sender, EventArgs a)
        {
            Navigation.RemovePage(this);
        }
    }
}