using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task1SphinxCommercial.BL.Entities;
using Task1SphinxCommercial.DAL.Interfaces;
using X.PagedList;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using X.PagedList.Extensions;

namespace Task1SphinxCommercial.UI.Pages.Products
{
    public class ListingProductsModel : PageModel
    {
        private readonly IProductRepository _productRepository;

        public IPagedList<Product> Products { get; set; } // Use IPagedList

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;

        public ListingProductsModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task OnGetAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();

            // Convert the result to IEnumerable before applying ToPagedList
            Products = products?.OrderBy(p => p.Name)
                               .AsEnumerable() // Convert to IEnumerable
                               .ToPagedList(PageNumber, 10); // Paging with 10 items per page
        }
    }
}
