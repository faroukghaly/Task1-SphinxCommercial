using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task1SphinxCommercial.BL.Entities;
using Task1SphinxCommercial.DAL.Interfaces;

namespace Task1SphinxCommercial.UI.Pages.Products
{
    public class ProductDetailsModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public Product ProductDetails { get; set; }

        public ProductDetailsModel(IProductRepository productRepository)
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
    }

}

