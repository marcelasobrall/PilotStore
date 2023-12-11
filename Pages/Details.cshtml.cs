using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PilotStore_.Models;
using PilotStore_.Services;  // Assuming IHamburguerService is in the Services namespace

namespace PilotStore_.Pages
{
    public class DetailsModel : PageModel
    {
        private IProductService _service;

        public DetailsModel(IProductService productService)
        {
            _service = productService;
        }

        public ProductModel Product { get; private set; }
        public Marca Marca { get; private set; }  // Adicione esta linha

        public IActionResult OnGet(int id)
        {
            Product = _service.Obter(id);
            Marca = _service.ObterTodasAsMarcas().SingleOrDefault(item => item.MarcaId == Product.MarcaId);

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}

