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
        public Task<string> SaveClientAsync(Client item, bool isNewItem = true)
        {
            Console.WriteLine(@"Am ajuns in baza de date");
            return restService.SaveClientAsync(item, isNewItem);
        }
        public Task SaveUserAsync(User item, bool isNewItem = true)
        {
            return restService.SaveUserAsync(item, isNewItem);
        }
        public Task DeleteClientAsync(Client item)
        {
            return restService.DeleteClientAsync(item.ID);
        }
        public Task DeleteUserAsync(User item)
        {
            return restService.DeleteUserAsync(item.ID);
        }
    }
}
