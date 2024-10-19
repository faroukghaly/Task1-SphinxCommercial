using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1SphinxCommercial.BL.Entities;

namespace Task1SphinxCommercial.DAL.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<List<Product>> GetAllProductsSortedByNameAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(int productId);
        Task<IList<Product>> GetActiveProductsAsync();
    }
}
