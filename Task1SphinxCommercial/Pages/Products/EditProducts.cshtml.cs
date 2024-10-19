using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task1SphinxCommercial.BL.Entities;
using Task1SphinxCommercial.DAL.Interfaces;

namespace Task1SphinxCommercial.UI.Pages.Products
{
    public class EditProductsModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        [BindProperty]
        public Product EditProduct { get; set; }

        public EditProductsModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            EditProduct = await _productRepository.GetProductByIdAsync(id);

            if (EditProduct == null)
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
            await _productRepository.UpdateProductAsync(EditProduct);
            return RedirectToPage("ListProducts");
        }
    }

}
