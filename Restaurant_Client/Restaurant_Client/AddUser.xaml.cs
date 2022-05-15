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
    public partial class AddUser : ContentPage
    {
        public AddUser()
        {
            InitializeComponent();
        }
        async void OnButtonSave(object sender, EventArgs e)
        {
            try
            {
                int n = (int)BindingContext;
                var user = new User
                {
                    Mail = txtmail.Text,
                    Parola = txtparola.Text,
                    Username = txtusr.Text,
                    Cli_ID = n
                };
                await App.Database.SaveUserAsync(user);
                await Navigation.PopToRootAsync();
                await DisplayAlert("URAA", user.ID.ToString(), "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("NEOK", ex.Message, "OK");
            }
        }
    }
}