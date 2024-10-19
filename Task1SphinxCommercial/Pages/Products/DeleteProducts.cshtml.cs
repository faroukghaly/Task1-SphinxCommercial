using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task1SphinxCommercial.BL.Entities;
using Task1SphinxCommercial.DAL.Interfaces;

namespace Task1SphinxCommercial.UI.Pages.Products
{
    public class DeleteProductsModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public Product ProductDetails { get; set; }

        public DeleteProductsModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            ProductDetails = await _productRepository.GetProductByIdAsync(id);
            if (ProductDetails == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var res = await _productRepository.DeleteProductAsync(id);
            if (res)
                return RedirectToPage("/Products/ListProducts"); 
            else
            {
                TempData["error"] = "Product is related to Client";
                
                return RedirectToPage("DeleteProducts", new { id });
            }

        }
    }
}
