using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task1SphinxCommercial.BL.Entities;

namespace Task1SphinxCommercial.DAL.Interfaces
{
    public interface IClientProductRepository
    {
        Task<List<ClientProduct>> GetAllClientProductsAsync();
        Task<ClientProduct> GetClientProductByIdAsync(int id);
        Task AddClientProductAsync(ClientProduct clientProduct);
        Task<bool> UpdateClientProductAsync(ClientProduct clientProduct);
        Task<bool> DeleteClientProductAsync(int id);
        Task<List<ClientProduct>> GetClientProductsByClientIdAsync(int id);
    }
}
