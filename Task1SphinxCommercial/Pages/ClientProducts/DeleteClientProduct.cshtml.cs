using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task1SphinxCommercial.BL.Entities;
using Task1SphinxCommercial.DAL.Interfaces;

namespace Task1SphinxCommercial.UI.Pages.ClientProducts
{
    public class DeleteClientProductsModel : PageModel
    {
        private readonly IClientProductRepository _clientProductRepository;
        private readonly IClientRepository _clientRepository;

        public DeleteClientProductsModel(IClientProductRepository clientProductRepository, IClientRepository clientRepository)
        {
            _clientProductRepository = clientProductRepository;
            _clientRepository = clientRepository;
        }

        [BindProperty]
        public ClientProduct ClientProduct { get; set; }

        public int ClientId { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            ClientProduct = await _clientProductRepository.GetClientProductByIdAsync(id);

            if (ClientProduct == null)
            {
                return NotFound();
            }

            ClientId = ClientProduct.ClientId;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            ClientProduct = await _clientProductRepository.GetClientProductByIdAsync(id);

            if (ClientProduct == null)
            {
                return NotFound();
            }

            var clientId = ClientProduct.ClientId; // Store the ClientId before deletion
            var success = await _clientProductRepository.DeleteClientProductAsync(id);

            if (success)
            {
                // Redirect to the ClientDetails page of the client after deletion
                return RedirectToPage("/Clients/ClientDetails", new { id = clientId });
            }

            ModelState.AddModelError(string.Empty, "Unable to delete the product.");
            return Page();
        }
    }
}

