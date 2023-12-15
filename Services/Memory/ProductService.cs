using System;
using System.Collections.Generic;
using System.Linq;
using PilotStore_.Models;

namespace PilotStore_.Services.Memory
{
    public class ProductService : IProductService
    {
        private IList<ProductModel> _products;

        public ProductService()
        {
            CarregarListaInicial();
        }

        private void CarregarListaInicial()
        {
            _products = new List<ProductModel>()
            {
                new ProductModel
                {
                    Id = 1,
                    Name = "Camisa",
                    Description = "Camisa Pilotos",
                    Price = 279,
                    ReleaseDate = DateTime.Parse("2023-01-15"),
                    ImagePath = "/images/product1-camisa.png",
                    IsActive = true
                },
                new ProductModel
                {
                    Id = 2,
                    Name = "Computador de Voo",
                    Description = "Para prova da ANAC",
                    Price = 210,
                    ReleaseDate = DateTime.Parse("2023-02-20"),
                    ImagePath = "/images/product2-computador-voo.png",
                    IsActive = true
                },
                new ProductModel
                {
                    Id = 3,
                    Name = "Chaveiro",
                    Description = "Chaveiro retire antes de voar",
                    Price =  40,
                    ReleaseDate = DateTime.Parse("2023-03-25"),
                    ImagePath = "/images/product3-chaveiro.png",
                    IsActive = false
                },
                new ProductModel
                {
                    Id = 4,
                    Name = "Quepe",
                    Description = "Quepe para pilotos",
                    Price = 220,
                    ReleaseDate = DateTime.Parse("2023-03-25"),
                    ImagePath = "/images/product4-quepe.png",
                    IsActive = true
                },
                new ProductModel
                {
                    Id = 5,
                    Name = "Par Berimbelas",
                    Description = "Berimbelas pretas básicas",
                    Price = 39,
                    ReleaseDate = DateTime.Parse("2023-03-25"),
                    ImagePath = "/images/product5-par-berimbelas.png",
                    IsActive = true
                },
                new ProductModel
                {
                    Id = 6,
                    Name = "Brevê Aviação",
                    Description = "Brasão da República",
                    Price = 39,
                    ReleaseDate = DateTime.Parse("2023-03-25"),
                    ImagePath = "/images/product6-breve-aviacao.png",
                    IsActive = false
                },

            };
        }

        public IList<ProductModel> ObterTodos()
        {
            return _products;
        }

        public ProductModel Obter(int id)
        {
            return _products.SingleOrDefault(item => item.Id == id);
        }

        public void Incluir(ProductModel product)
        {
            var nextId = _products.Max(item => item.Id) + 1;
            product.Id = nextId;
            _products.Add(product);
        }


        public void Alterar(ProductModel product)
        {
            var productFound = Obter(product.Id);
            if (productFound != null)
            {
                productFound.Name = product.Name;
                productFound.Description = product.Description;
                productFound.IsActive = product.IsActive;
                productFound.Price = product.Price;
                productFound.ReleaseDate = product.ReleaseDate;
                productFound.ImagePath = product.ImagePath;

            }
        }

        public void Excluir(int id)
        {
            var productFound = Obter(id);
            if (productFound != null)
            {
                _products.Remove(productFound);
            }
        }

        public IList<Marca> ObterTodasAsMarcas()
        {
            return new List<Marca>()
            {
                new Marca() { Descricao = "Flight Outfitters"},
                new Marca() { Descricao = "ASA"},
                new Marca() { Descricao = "AOPA Pilot Gear"},
            };
        }
    }
}
