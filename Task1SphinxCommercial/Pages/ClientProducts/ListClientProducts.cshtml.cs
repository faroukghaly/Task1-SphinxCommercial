using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task1SphinxCommercial.BL.Entities;
using Task1SphinxCommercial.DAL.Interfaces;
using Task1SphinxCommercial.DAL.Repositories;

namespace Task1SphinxCommercial.UI.Pages.ClientProducts
{
    public class ListClientProductsModel : PageModel
    {
        private readonly IClientProductRepository _clientProductRepository;

        public ListClientProductsModel(IClientProductRepository clientProductRepository)
        {
            _clientProductRepository = clientProductRepository;
        }

        public IList<ClientProduct> ClientProducts { get; set; } = new List<ClientProduct>();
        public int PageSize { get; set; } = 3; 
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
       
        public async Task OnGetAsync(int pageIndex = 1)
        {
            var allProducts = await _clientProductRepository.GetAllClientProductsAsync();

            if (allProducts != null)
            {
                ClientProducts = allProducts.OrderBy(p => p.StartDate) 
                                      .Skip((pageIndex - 1) * PageSize)
                                      .Take(PageSize)
                                      .ToList();

                // Calculate total pages based on the number of products and page size
                TotalPages = (int)Math.Ceiling(allProducts.Count() / (double)PageSize);
            }

            CurrentPage = pageIndex;
        }
    }
}
