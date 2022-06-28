using System;
using System.Collections.Generic;
using System.Text;
using Restaurant_Client.Models;
using System.Threading.Tasks;

namespace Restaurant_Client.Data
{
    public class LicentaDB
    {
        readonly IRestService restService;
        public LicentaDB(IRestService service)
        {
            restService = service;
        }
        public Task<List<Client>> GetClientsAsync()
        {
            return restService.RefreshDataAsyncCLI();
        }
        public Task<List<User>> GetUsersAsync()
        {
            Console.WriteLine(@"Am ajuns in baza de date sa afisez userii");
            return restService.RefreshDataAsyncUSR();
        }
        public Task<List<Fel_m>> GetFeluriAsync()
        {
            return restService.RefreshDataAsyncFEL();
        }
        public Task<List<Produs>> GetProduseAsync()
        {
            Console.Write(@"Al doilea pas in LicentaDB");
            return restService.RefreshDataAsyncPROD();
        }
        public Task<string> SaveClientAsync(Client item, bool isNewItem = true)
        {
            Console.WriteLine(@"Am ajuns in baza de date");
            return restService.SaveClientAsync(item, isNewItem);
        }
        public Task SaveUserAsync(User item, bool isNewItem = true)
        {
            return restService.SaveUserAsync(item, isNewItem);
        }
        public Task SaveFeluriAsync(Fel_m item, bool isNewItem = true)
        {
            Console.WriteLine(@"Am ajuns in baza de date");
            return restService.SaveFelAsync(item, isNewItem);
        }
        public Task SaveProduseAsync(Produs item, bool isNewItem = true)
        {
            return restService.SaveProdusAsync(item, isNewItem);
        }
        public Task DeleteClientAsync(Client item)
        {
            return restService.DeleteClientAsync(item.ID);
        }
        public Task DeleteUserAsync(User item)
        {
            return restService.DeleteUserAsync(item.ID);
        }
        public Task DeleteFeluriAsync(Fel_m item)
        {
            return restService.DeleteFelAsync(item.ID);
        }
        public Task DeleteProduseAsync(Produs item)
        {
            return restService.DeleteProdusAsync(item.ID);
        }
        public Task<List<Masa>> GetMeseAsync()
        {
            return restService.RefreshDataAsyncMASA();
        }
        public Task<List<Comanda>> GetComenziAsync()
        {
            return restService.RefreshDataAsyncCOM();
        }
        public Task<string> SaveCOMANDAAsync(Comanda item, bool isNewItem = true)
        {
            Console.WriteLine(@"Am ajuns in baza de date");
            return restService.SaveComandaAsync(item, isNewItem);
        }
        public Task DeleteComenziAsync(int id)
        {
            return restService.DeleteComandaAsync(id);
        }
        public Task<Comanda> GetComanda(int id)
        {
            return restService.GetComandaById(id);
        }
        public Task SaveTable(Masa m, bool isNewItem = false)
        {
            return restService.SaveMasaAsync(m, isNewItem);
        }
        public Task DeleteRezAsync(int id)
        {
            return restService.DeleteRezAsync(id);
        }
        public Task<List<Produs_cos>> GetCos(int id)
        {
            return restService.RefreshDataAsyncREZ(id);
        }
        public Task SaveRez(Rezervare r, bool isNewItem = true)
        {
            return restService.SaveRezAsync(r, isNewItem);
        }
        public Task DeleteMasa(int id)
        {
            return restService.DeleteMasaAsync(id);
        }
    }
}
