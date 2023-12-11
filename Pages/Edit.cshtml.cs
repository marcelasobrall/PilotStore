using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PilotStore_.Models;
using PilotStore_.Services;

namespace PilotStore_.Pages
{
    public class EditModel : PageModel
    {
        private IProductService _service;

        public EditModel(IProductService productService)
        {
            _service = productService;
        }

        [BindProperty]
        public ProductModel Product { get; set; }

        public void OnGet(int id)
            => Product = _service.Obter(id);

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.Alterar(Product);

            return RedirectToPage("/Index");
        }

        public IActionResult OnPostDelete()
        {
            _service.Excluir(Product.Id);

            TempData["TempMensagemSucesso"] = true;

            return RedirectToPage("/Index");
        }
    }
}
