using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Restaurant_Client.Models;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Restaurant_Client
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddClient : ContentPage
    {
        public AddClient()
        {
            InitializeComponent();
        }
        async void OnButtonSave(object sender, EventArgs e)
        {
            try
            {
                var cli = new Client
                {
                    Nume = txtnume.Text,
                    Prenume = txtprenume.Text,
                    Data_nast = txtdat.Date,
                    Telefon = txttlf.Text,
                    Adresa = txtadr.Text
                };
                var ok = true;
                if(txtnume.Text.Length==0 || txtprenume.Text.Length==0 || txttlf.Text.Length==0)
                {
                    await DisplayAlert("Nume, Prenume, Telefon", "Primele trei campuri sunt obligatorii", "OK");
                    ok = false;
                }
                if (GDPR.IsChecked==false)
                {
                    await DisplayAlert("GDPR", "Procesul nu poate fi finalizat fără acordul prelucrării datelor", "OK");
                    ok = false;
                }
                DateTime newDate = new DateTime(2004, 1, 1);
                if (DateTime.Compare(newDate,cli.Data_nast)<0)
                {
                    Console.WriteLine(DateTime.Compare(newDate, cli.Data_nast).ToString());
                    await DisplayAlert("Varsta", "Trebuie sa aveti peste 18 ani", "OK");
                    ok = false;
                }
                Console.WriteLine(ok.ToString());
                if (ok)
                {
                    string s = await App.Database.SaveClientAsync(cli);
                    //Console.WriteLine(s);
                    string nr = new string(s.Reverse().ToArray());
                    //Console.WriteLine(nr);
                    Regex re = new Regex(@"\d+");
                    var id = re.Match(nr);
                    //Console.WriteLine(id.ToString());
                    string id2 = new string(id.ToString().Reverse().ToArray());
                    int id3 = Int32.Parse(id2);
                    Console.WriteLine(id3.ToString());
                    await Navigation.PushAsync(new AddUser
                    {
                        BindingContext = id3
                    });
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("NEOK", ex.Message, "OK");
            }
        }
    }
}