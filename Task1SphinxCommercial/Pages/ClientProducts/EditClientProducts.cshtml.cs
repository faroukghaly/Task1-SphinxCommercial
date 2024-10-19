using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task1SphinxCommercial.BL.Entities;
using Task1SphinxCommercial.DAL.Interfaces;

namespace Task1SphinxCommercial.UI.Pages.ClientProducts
{
    public class EditClientProductsModel : PageModel
    {
        private readonly IClientProductRepository _clientProductRepository;

        [BindProperty]
        public ClientProduct EditClientProducts { get; set; }

        public EditClientProductsModel(IClientProductRepository clientProductRepository)
        {
            _clientProductRepository = clientProductRepository;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            EditClientProducts = await _clientProductRepository.GetClientProductByIdAsync(id);

            if (EditClientProducts == null)
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

            var success = await _clientProductRepository.UpdateClientProductAsync(EditClientProducts);

            if (!success)
            {
                ModelState.AddModelError(string.Empty, "Unable to update ClientProduct.");
                return Page();
            }
            var r = TempData["id"];
            return RedirectToPage("ListClientProducts");

        }
    }
}

