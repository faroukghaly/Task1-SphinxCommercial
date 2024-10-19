using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1SphinxCommercial.BL.Entities;
using Task1SphinxCommercial.DAL.Interfaces;

namespace Task1SphinxCommercial.UI.Pages.ClientProducts
{
    public class AddClientProductsModel : PageModel
    {
        private readonly IClientProductRepository _clientProductRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IProductRepository _productRepository;

        [BindProperty]
        public ClientProduct NewClientProduct { get; set; }

        public List<Client> Clients { get; set; }
        public List<Product> Products { get; set; }

        public AddClientProductsModel(
            IClientProductRepository clientProductRepository,
            IClientRepository clientRepository,
            IProductRepository productRepository)
        {
            _clientProductRepository = clientProductRepository;
            _clientRepository = clientRepository;
            _productRepository = productRepository;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            // Fetching clients and active products
            Clients = await _clientRepository.GetAllClientsAsync();
            Products = (await _productRepository.GetActiveProductsAsync()).ToList(); 

            if (!Clients.Any() || !Products.Any())
            {
                ModelState.AddModelError(string.Empty, "No clients or products available for selection.");
                return Page();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Re-populate Clients and Products if form submission fails
                Clients = await _clientRepository.GetAllClientsAsync();
                Products = (await _productRepository.GetActiveProductsAsync()).ToList();
                return Page();
            }

            await _clientProductRepository.AddClientProductAsync(NewClientProduct);
            return RedirectToPage("ListClientProducts");
        }
    }
}
