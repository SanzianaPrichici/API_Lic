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
                var ok = true;
                if (txtmail.Text.IndexOf('@') == -1)
                {
                    await DisplayAlert("Mail", "Utilizati o adresa de mail conforma", "ok");
                    ok = false;
                }
                List<User> U = await App.Database.GetUsersAsync();
                foreach (User u in U)
                {
                    if (u.Username == txtusr.Text || u.Mail==txtmail.Text)
                    {
                        ok = false;
                        await DisplayAlert("User", "Userul este deja utilizat. Alegeti altul!", "ok");
                    }
                }
                if(txtparola.Text != txtparolacnf.Text)
                {
                    await DisplayAlert("Parola", "Parola nu corespune. Reincercati!", "ok");
                    ok = false;
                }
                if (ok)
                {
                    await App.Database.SaveUserAsync(user);
                    await Navigation.PopToRootAsync();
                    await DisplayAlert("User", "S-a inregistrat!", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("NEOK", ex.Message, "OK");
            }
        }
    }
}