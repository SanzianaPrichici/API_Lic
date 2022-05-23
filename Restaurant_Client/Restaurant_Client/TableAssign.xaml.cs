﻿using System;
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
    public partial class TableAssign : ContentPage
    {
        public TableAssign()
        {
            InitializeComponent();
        }
        async protected override void OnAppearing()
        {
            base.OnAppearing();
            listaMese.ItemsSource = await App.Database.GetProduseAsync();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        async void CautaMese(object sender, EventArgs e)
        {
            List<Masa> M = await App.Database.GetMeseAsync();
            List<Masa> Copie = new List<Masa>();
            int nr=Int32.Parse(nrPers.Text);
            int min = 100;
            foreach(Masa m in M)
            {
                //Console.WriteLine(m.Nr_pers.ToString());
                if (m.Nr_pers >= nr && m.Nr_pers < min && m.Dispo == true)
                    min = m.Nr_pers;
            }
            Console.WriteLine(min.ToString());
            foreach (Masa m in M)
            {
                if (m.Nr_pers == min && m.Dispo == true)
                    Copie.Add(m);
            }
            listaMese.ItemsSource = null;
            listaMese.ItemsSource = Copie;
        }
    }
}