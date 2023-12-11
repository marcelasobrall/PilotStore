using PilotStore_.Models;

namespace PilotStore_.Services
{
    public interface IProductService
    {
        IList<ProductModel> ObterTodos();
        ProductModel Obter(int id);
        void Incluir(ProductModel product);
        void Alterar(ProductModel product);
        void Excluir(int id);
        IList<Marca> ObterTodasAsMarcas();
    }
}
