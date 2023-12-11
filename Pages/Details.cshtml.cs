using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PilotStore_.Models;
using PilotStore_.Services;  // Assuming IHamburguerService is in the Services namespace

namespace PilotStore_.Pages
{
    public class DetailsModel : PageModel
    {
        private IProductService _service;  // Update to IProductService

        public DetailsModel(IProductService productService)  // Update to IProductService
        {
            _service = productService;
        }

        public ProductModel Product { get; private set; }  // Update to ProductModel

        public IActionResult OnGet(int id)
        {
            Product = _service.Obter(id);  // Update to Obter method

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}

