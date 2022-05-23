﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Restaurant_Client.Models;

namespace Restaurant_Client.Data
{
    public class RestService : IRestService
    {
        readonly HttpClient client;
        readonly string RestUrlCLI = "https://192.168.0.100:45455/api/Clients/";
        readonly string RestUrlUSR = "https://192.168.0.100:45455/api/Users/";
        readonly string RestUrlFEL = "https://192.168.0.100:45455/api/Fels/";
        readonly string RestUrlPROD = "https://192.168.0.100:45455/api/Produs/";
        readonly string RestUrlMASA = "https://192.168.0.100:45455/api/Masas/";
        public List<Client> Clients { get; private set; }
        public List<User> Users { get; private set; }
        public List<Fel_m> Feluri { get; private set; }
        public List<Produs> Produse { get; private set; }
        public List<Masa> Mese { get; private set; }
        public RestService()
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };
            client = new HttpClient(httpClientHandler);
        }
        public async Task<List<Masa>> RefreshDataAsyncMASA()
        {
            Console.Write("am ajuns la rest service");
            Mese = new List<Masa>();
            Uri uri = new Uri(string.Format(RestUrlMASA, string.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                Console.Write(response.IsSuccessStatusCode.ToString());
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Mese = JsonConvert.DeserializeObject<List<Masa>>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Eroare afisare Mese", ex.Message);
            }
            return Mese;
        }
        //Afisare lista clienti
        public async Task<List<Client>> RefreshDataAsyncCLI()
        {
            Clients = new List<Client>();
            Uri uri = new Uri(string.Format(RestUrlCLI, string.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Clients = JsonConvert.DeserializeObject<List<Client>>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Eroare afisare clienti", ex.Message);
            }
            return Clients;
        }
        //public async Task<List<Produs>> Products_Sorted()
        //{
         //   Produse = await RefreshDataAsyncPROD();
        //}
        //Afisare lista useri
        public async Task<List<User>> RefreshDataAsyncUSR()
        {
            Console.WriteLine(@"Am ajuns in baza de date sa afisez userii");
            Users = new List<User>();
            Uri uri = new Uri(string.Format(RestUrlUSR, string.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Users = JsonConvert.DeserializeObject<List<User>>(content);
                    Console.WriteLine(Users.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Eroare afisare useri", ex.Message);
            }
            return Users;
        }
        //Afisare Feluri de mancare
        public async Task<List<Fel_m>> RefreshDataAsyncFEL()
        {
            Feluri = new List<Fel_m>();
            Uri uri = new Uri(string.Format(RestUrlFEL, string.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Feluri = JsonConvert.DeserializeObject<List<Fel_m>>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Eroare afisare feluri", ex.Message);
            }
            return Feluri;
        }
        //Afisare Produse
        public async Task<List<Produs>> RefreshDataAsyncPROD()
        {
            Produse = new List<Produs>();
            Uri uri = new Uri(string.Format(RestUrlPROD, string.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"Am ajuns la produse");
                    string content = await response.Content.ReadAsStringAsync();
                    Produse = JsonConvert.DeserializeObject<List<Produs>>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Eroare afisare produse", ex.Message);
            }
            return Produse;
        }
        // Salvare Client
        public async Task<string> SaveClientAsync(Client item, bool isNewItem = true)
        {
            Console.WriteLine(@"Am ajuns la URL");
            Uri uri = new Uri(string.Format(RestUrlCLI, string.Empty));
            try
            {
                string json = JsonConvert.SerializeObject(item);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                    return response.Headers.Location.ToString();
                }
                Console.WriteLine(response.IsSuccessStatusCode.ToString());
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"S-a salvat clientul.");
                    return response.Headers.Location.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Clientul nu poate fi salvat", ex.Message);
            }
            return null;
        }
        //Salvare fel de mancare
        public async Task SaveFelAsync(Fel_m item, bool isNewItem = true)
        {
            Console.WriteLine(@"Am ajuns la URL");
            Uri uri = new Uri(string.Format(RestUrlFEL, string.Empty));
            try
            {
                string json = JsonConvert.SerializeObject(item);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }
                Console.WriteLine(response.IsSuccessStatusCode.ToString());
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"S-a salvat felul.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Felul nu poate fi salvat", ex.Message);
            }
        }
        //Salvare produs
        public async Task SaveProdusAsync(Produs item, bool isNewItem = true)
        {
            Console.WriteLine(@"Am ajuns la URL");
            Uri uri = new Uri(string.Format(RestUrlPROD, string.Empty));
            try
            {
                string json = JsonConvert.SerializeObject(item);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }
                Console.WriteLine(response.IsSuccessStatusCode.ToString());
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"S-a salvat produsul.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Produsul nu poate fi salvat", ex.Message);
            }
        }
        // Salvare User
        public async Task SaveUserAsync(User item, bool isNewItem = true)
        {
            Console.WriteLine(@"Am ajuns la URLul pt user");
            Uri uri = new Uri(string.Format(RestUrlUSR, string.Empty));
            try
            {
                string json = JsonConvert.SerializeObject(item);
                Console.WriteLine(json);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    Console.WriteLine(@"Ceva POST.");
                    response = await client.PostAsync(uri, content);
                    Console.WriteLine(response.Headers.ToString());
                }
                else
                {
                    Console.WriteLine(@"Ceva PUT.");
                    response = await client.PutAsync(uri, content);
                }
                Console.WriteLine(response.IsSuccessStatusCode.ToString());
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"S-a salvat userul.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Userul nu poate fi salvat", ex.Message);
            }
        }
        //Stergere Client
        public async Task DeleteClientAsync(int id)
        {
            Uri uri = new Uri(string.Format(RestUrlCLI, id));
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"Clientul a fost sters");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Clientul nu poate fi sters", ex.Message);
            }
        }
        //Stergere User
        public async Task DeleteUserAsync(int id)
        {
            Uri uri = new Uri(string.Format(RestUrlUSR, id));
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"Userul a fost sters");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Userul nu poate fi sters", ex.Message);
            }
        }
        //Stergere Fel de mancare
        public async Task DeleteFelAsync(int id)
        {
            Uri uri = new Uri(string.Format(RestUrlFEL, id));
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"Felul a fost sters");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Felul nu poate fi sters", ex.Message);
            }
        }
        //Stergere Fel de mancare
        public async Task DeleteProdusAsync(int id)
        {
            Uri uri = new Uri(string.Format(RestUrlPROD, id));
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(@"Produsul a fost sters");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Produsul nu poate fi sters", ex.Message);
            }
        }
        //Afisare Mese
        
    }
}
