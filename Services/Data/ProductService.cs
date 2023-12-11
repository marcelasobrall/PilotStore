using PilotStore_.Data;
using PilotStore_.Models;

namespace PilotStore_.Services.Data;

public class ProductService : IProductService
{
    private PilotStoreDbContext _context;
    public ProductService(PilotStoreDbContext context)
    {
        _context = context;
    }

    public void Alterar(ProductModel product)
    {
        var productFound = Obter(product.Id);
        productFound.Name = product.Name;
        productFound.Description = product.Description;
        productFound.IsActive = product.IsActive;
        productFound.Price = product.Price;
        productFound.ReleaseDate = product.ReleaseDate;
        productFound.ImagePath = product.ImagePath;

        _context.SaveChanges();
     }

    public void Excluir(int id)
    {
        var productFound = Obter(id);
        _context.Products.Remove(productFound);
        _context.SaveChanges();
    }

    public void Incluir(ProductModel product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public ProductModel Obter(int id)
    {
        return _context.Products.SingleOrDefault(item => item.Id  == id);
    }

    public IList<Marca> ObterTodasAsMarcas()
    {
        return _context.Marca.ToList();
    }

    public IList<ProductModel> ObterTodos()
    {
        return _context.Products.ToList();
    }
}
