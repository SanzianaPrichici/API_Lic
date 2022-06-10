using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Restaurant_Client.Models;

namespace Restaurant_Client.Data
{
    public interface IRestService
    {
        //Implementare CLIENTI
        Task<List<Client>> RefreshDataAsyncCLI();
        Task<string> SaveClientAsync(Client item, bool isNewItem);
        Task DeleteClientAsync(int id);
        //Implementare USERI
        Task<List<User>> RefreshDataAsyncUSR();
        Task SaveUserAsync(User item, bool isNewItem);
        Task DeleteUserAsync(int id);
        //Implementare FELURI DE MANCARE
        Task<List<Fel_m>> RefreshDataAsyncFEL();
        Task SaveFelAsync(Fel_m item, bool isNewItem);
        Task DeleteFelAsync(int id);
        //Implementare PRODUSE
        Task<List<Produs>> RefreshDataAsyncPROD();
        Task SaveProdusAsync(Produs item, bool isNewItem);
        Task DeleteProdusAsync(int id);
        //Implementare mese
        Task<List<Masa>> RefreshDataAsyncMASA();
        //Implementare comenzi
        Task<List<Comanda>> RefreshDataAsyncCOM();
        Task<string> SaveComandaAsync(Comanda item, bool isNewItem);
        Task DeleteComandaAsync(int id);
    }
}
