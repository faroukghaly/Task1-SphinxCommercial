using Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task1SphinxCommercial.BL.Entities;
using Task1SphinxCommercial.DAL.Interfaces;

namespace Task1SphinxCommercial.DAL.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly SphinxDbContext _context;

        public ClientRepository(SphinxDbContext context)
        {
            _context = context;
        }

        #region GET
        public async Task<List<Client>> GetAllClientsAsync()
        {
            return await _context.Clients.OrderBy(c => c.Code).ToListAsync();
        }
        public async Task<IEnumerable<object>> GetClientsAsync()
        {
            return await _context.Clients.Select(c => new { c.Name, c.Code }).ToListAsync();
        }
        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        #endregion

        #region ADD
        public async Task AddClientAsync(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region UPDATE
        public async Task UpdateClientAsync(Client client)
        {
            var existingClient = await _context.Clients.FindAsync(client.ClientId);
            if (existingClient != null)
            {
                // Update only the fields that need to be changed, and not the Code field to avoid duplication
                existingClient.Name = client.Name;
                existingClient.Class = client.Class;
                existingClient.State = client.State;
                await _context.SaveChangesAsync();
            }
        }
        #endregion

        #region DELETE
        public async Task DeleteClientAsync(int id)
        {
            // Find the client by its ID
            var client = await _context.Clients
                                       .FirstOrDefaultAsync(c => c.ClientId == id);

            // Check if the client exists
            if (client == null)
            {
                throw new InvalidOperationException("Client not found.");
            }

            // Check if the client has related ClientProducts
            var hasRelatedClientProducts = await _context.ClientProducts
                                                         .AnyAsync(cp => cp.ClientId == id);

            //if (hasRelatedClientProducts)
            //{
            //    throw new InvalidOperationException("Cannot delete client with related ClientProducts.");
            //}

            // Remove the client if no related ClientProducts exist
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
        }

        #endregion

    }
}
