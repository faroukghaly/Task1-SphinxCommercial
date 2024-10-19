using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task1SphinxCommercial.BL.Entities;
using Task1SphinxCommercial.DAL.Interfaces;

namespace Task1SphinxCommercial.UI.Pages.Clients
{
    public class AddClientsModel : PageModel
    {
        private readonly IClientRepository _clientRepository;

        [BindProperty]
        public Client NewClient { get; set; }

        public AddClientsModel(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); 
            }

            await _clientRepository.AddClientAsync(NewClient);
            return RedirectToPage("ListClients"); 
        }
    }

}
