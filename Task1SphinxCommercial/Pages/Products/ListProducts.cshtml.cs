using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task1SphinxCommercial.BL.Entities;
using Task1SphinxCommercial.DAL.Interfaces;

namespace Task1SphinxCommercial.UI.Pages.Products
{
    public class ListProductsModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public IList<Product> Products { get; set; } = new List<Product>();
        public int PageSize { get; set; } = 3; 
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public ListProductsModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        
        public async Task OnGetAsync(int pageIndex = 1)
        {
            var allProducts = await _productRepository.GetAllProductsSortedByNameAsync();

            if (allProducts != null)
            {
                Products = allProducts.OrderBy(p => p.Name) 
                                      .Skip((pageIndex - 1) * PageSize)
                                      .Take(PageSize)
                                      .ToList();

                TotalPages = (int)Math.Ceiling(allProducts.Count() / (double)PageSize);
            }

            CurrentPage = pageIndex;
        }
    }
}
