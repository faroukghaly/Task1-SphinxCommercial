using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task1SphinxCommercial.BL.Entities;
using Task1SphinxCommercial.DAL.Interfaces;

namespace Task1SphinxCommercial.UI.Pages.Clients
{
    public class DeleteClientsModel : PageModel
    {
        private readonly IClientRepository _clientRepository;

        public Client ClientDetails { get; set; }

        public DeleteClientsModel(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            ClientDetails = await _clientRepository.GetClientByIdAsync(id);
            if (ClientDetails == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            try
            {
                await _clientRepository.DeleteClientAsync(id);
                return RedirectToPage("/Clients/ListClients");
            }
            catch (InvalidOperationException ex)
            {
                // If delete fails (e.g., related ClientProducts), show an error message
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
        }
    }
}
