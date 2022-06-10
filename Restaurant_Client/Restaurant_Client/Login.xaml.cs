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
    public partial class Login : ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        public Login()
        {
            InitializeComponent();
        }
        async void OnInregClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddClient
            {
                BindingContext = new Client()
            });
        }
        async void OnLoginClicked(object sender, EventArgs e)
        {
            var User = new User()
            {
                Username = txtusername.Text,
                Parola = txtpassword.Text
            };
            var isValid = await CorectUser(User);
            Console.WriteLine(isValid.ToString());
            if (isValid)
            {
                Console.WriteLine("Userul este ok");
                App.IsUserLoggedIn = true;
                Navigation.InsertPageBefore(new NavigationPage (new TableAssign()), this);
                await Navigation.PopToRootAsync();
                //await Navigation.PushAsync(new NavigationPage(new Meniu()));
            }
            else
            {
                await DisplayAlert("USER INCORECT", "Introduceti corect userul", "OK");
                txtpassword.Text = txtusername.Text = string.Empty;
            }
        }
        async Task<bool> CorectUser(User user)
        {
            List<User> Useri = await App.Database.GetUsersAsync();
            foreach(User u in Useri)
            {
                if (u.Username == user.Username && u.Parola == user.Parola)
                {
                    App.UserID = u.ID;
                    Console.WriteLine(App.UserID.ToString());
                    return true;
                }
            }
            return false;
        }
    }
}