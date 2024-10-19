using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task1SphinxCommercial.BL.Entities;
using Task1SphinxCommercial.DAL.Interfaces;

namespace Task1SphinxCommercial.UI.Pages.Clients
{
    public class ListClientsModel : PageModel
    {
        private readonly IClientRepository _clientRepository;

        public ListClientsModel(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public IList<Client> Clients { get; set; } = new List<Client>();
        public int PageSize { get; set; } = 3; 
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public async Task OnGetAsync(int pageIndex = 1)
        {
            var allClients = await _clientRepository.GetAllClientsAsync();

            // Ensure it's not null to avoid potential issues
            if (allClients != null)
            {
                Clients = allClients.OrderBy(c => c.Code)
                                    .Skip((pageIndex - 1) * PageSize)
                                    .Take(PageSize)
                                    .ToList();

                // Calculate total pages based on the number of clients and page size
                TotalPages = (int)Math.Ceiling(allClients.Count() / (double)PageSize);
            }

            CurrentPage = pageIndex;
        }
    }
}

