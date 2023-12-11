using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PilotStore_.Models;
using PilotStore_.Services;
using System.Collections.Generic;

namespace PilotStore_.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _service;

        public IndexModel(IProductService productService)
        {
            _service = productService;
        }

        public IList<ProductModel> ListaProduct { get; private set; }

        public void OnGet()
        {
            ViewData["Title"] = "Home page";

            ListaProduct = _service.ObterTodos();
        }
    }
}
