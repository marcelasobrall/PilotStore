using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PilotStore_.Models;
using PilotStore_.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace PilotStore_.Pages
{
    [Authorize]
    public class EditModel : PageModel
    {
        private IProductService _service;

        public SelectList MarcaOptionItems { get; set; }

        public EditModel(IProductService productService)
        {
            _service = productService;
        }

        [BindProperty]
        public ProductModel Product { get; set; }

        public void OnGet(int id)
        {
            Product = _service.Obter(id);

            if (Product == null)
            {
                RedirectToPage("/Index");
            }

            MarcaOptionItems = new SelectList(_service.ObterTodasAsMarcas(),
                nameof(Marca.MarcaId),
                nameof(Marca.Descricao));
        }

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
