using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task1SphinxCommercial.BL.Entities;
using Task1SphinxCommercial.DAL.Interfaces;
using Task1SphinxCommercial.DAL.Repositories;

namespace Task1SphinxCommercial.UI.Pages.Clients
{
    public class ClientDetailsModel : PageModel
    {
        private readonly IClientRepository _clientRepository;
        private readonly IClientProductRepository _clientProductRepository;
        private readonly IProductRepository _productRepository;

        public Client ClientDetails { get; set; }
        public List<ClientProduct> ClientProducts { get; set; }

        public ClientDetailsModel(IClientRepository clientRepository, IClientProductRepository clientProductRepository)
        {
            _clientRepository = clientRepository;
            _clientProductRepository = clientProductRepository;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            ClientDetails = await _clientRepository.GetClientByIdAsync(id);
            if (ClientDetails == null)
            {
                return NotFound();
            }

            // Fetch related ClientProducts sorted by Product Name
            ClientProducts = await _clientProductRepository.GetClientProductsByClientIdAsync(id);
            return Page();
        }
    }
}

