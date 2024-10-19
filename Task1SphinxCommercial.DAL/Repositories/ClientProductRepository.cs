using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1SphinxCommercial.BL.Entities;

using Task1SphinxCommercial.DAL.Interfaces;
using Data;
namespace Task1SphinxCommercial.DAL.Repositories
{
    public class ClientProductRepository : IClientProductRepository
    {
        private readonly SphinxDbContext _context;

        public ClientProductRepository(SphinxDbContext context)
        {
            _context = context;
        }

        #region GET
        public async Task<List<ClientProduct>> GetAllClientProductsAsync()
        {
            return await _context.ClientProducts.Include(cp => cp.Client).Include(cp => cp.Product).ToListAsync();
        }

        public async Task<ClientProduct> GetClientProductByIdAsync(int id)
        {
            return await _context.ClientProducts
                .Include(cp => cp.Client)
                .Include(cp => cp.Product)
                .FirstOrDefaultAsync(cp => cp.ClientProductId == id);
        }
        public async Task<List<ClientProduct>> GetClientProductsByClientIdAsync(int id)
        {
            return await _context.ClientProducts
                .Where(cp => cp.ClientId == id)
                .Include(cp => cp.Product)
                .OrderBy(cp => cp.Product.Name)
                .ToListAsync();
        }

        #endregion

        #region Add
        public async Task AddClientProductAsync(ClientProduct clientProduct)
        {
            await _context.ClientProducts.AddAsync(clientProduct);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region UPDATE
        public async Task<bool> UpdateClientProductAsync(ClientProduct clientProduct)
        {
            var existingProduct = await _context.ClientProducts.FindAsync(clientProduct.ClientProductId);
            if (existingProduct != null)
            {
                existingProduct.License = clientProduct.License;
                existingProduct.StartDate = clientProduct.StartDate;
                existingProduct.EndDate = clientProduct.EndDate;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;  // Return false if the product wasn't found
        }

        #endregion

        #region DELETE
        public async Task<bool> DeleteClientProductAsync(int id)
        {
            var clientProduct = await _context.ClientProducts.FindAsync(id);
            if (clientProduct != null)
            {
                _context.ClientProducts.Remove(clientProduct);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        #endregion

    }
}
