using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1SphinxCommercial.BL.Entities;
using Task1SphinxCommercial.DAL.Interfaces;

namespace Task1SphinxCommercial.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SphinxDbContext _context;

        public ProductRepository(SphinxDbContext context)
        {
            _context = context;
        }

        #region GET
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        public async Task<List<Product>> GetAllProductsSortedByNameAsync()
        {
            return await _context.Products
                                 .OrderBy(p => p.Name)
                                 .ToListAsync();
        }
        public async Task<IList<Product>> GetActiveProductsAsync()
        {
            return await _context.Products
                                 .Where(p => p.IsActive) // Ensure the IsActive flag is checked
                                 .ToListAsync();
        }
        #endregion

        #region ADD
        public async Task AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }


        #endregion

        #region UPDATE
        public async Task UpdateProductAsync(Product product)
        {
            var existingProduct = await _context.Products.FindAsync(product.ProductId);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.IsActive = product.IsActive;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Product not found.");
            }
        }
        #endregion

        #region DELETE
        public async Task<bool> DeleteProductAsync(int productId)
        {
            var clientProducts = await _context.ClientProducts
                .Where(cp => cp.ProductId == productId)
                .ToListAsync();

            if (clientProducts.Any())
            {
                return false;
            }

            var product = await _context.Products.FindAsync(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        } 
        #endregion

    }
}
