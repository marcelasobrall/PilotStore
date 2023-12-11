using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PilotStore_.Models;
using PilotStore_.Services;

namespace PilotStore_.Pages
{
    public class CreateModel : PageModel
    {
        private IProductService _service;

        public SelectList MarcaOptionItems { get; set; }

        public CreateModel(IProductService productService)
        {
            _service = productService;
        }

        public void OnGet()
        {
            MarcaOptionItems = new SelectList(_service.ObterTodasAsMarcas(),
                nameof(Marca.MarcaId),
                nameof(Marca.Descricao));
 
        }

        [BindProperty]
        public ProductModel Product { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.Incluir(Product);

            return RedirectToPage("/Index");
        }
    }
}

