using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task1SphinxCommercial.BL.Entities;
using Task1SphinxCommercial.DAL.Interfaces;

namespace Task1SphinxCommercial.UI.Pages.Products
{
    public class AddProductsModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        [BindProperty]
        public Product NewProduct { get; set; }

        public AddProductsModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void OnGet() { } 

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _productRepository.AddProductAsync(NewProduct);
            return RedirectToPage("ListProducts"); 
        }
    }

}

