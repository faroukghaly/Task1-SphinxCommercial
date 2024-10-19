using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task1SphinxCommercial.BL.Entities;
using Task1SphinxCommercial.DAL.Interfaces;

namespace Task1SphinxCommercial.UI.Pages.Clients
{
    public class EditClientsModel : PageModel
    {
        private readonly IClientRepository _clientRepository;

        [BindProperty]
        public Client EditClient { get; set; }

        public EditClientsModel(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            EditClient = await _clientRepository.GetClientByIdAsync(id);

            if (EditClient == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _clientRepository.UpdateClientAsync(EditClient);
            return RedirectToPage("ListClients");
        }
    }

}

