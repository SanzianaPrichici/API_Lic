using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Restaurant_Client.Models;

namespace Restaurant_Client.Data
{
    public interface IRestService
    {
        Task<List<Client>> RefreshDataAsyncCLI();
        Task<string> SaveClientAsync(Client item, bool isNewItem);
        Task DeleteClientAsync(int id);
        Task<List<User>> RefreshDataAsyncUSR();
        Task SaveUserAsync(User item, bool isNewItem);
        Task DeleteUserAsync(int id);
    }
}
