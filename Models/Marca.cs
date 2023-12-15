namespace PilotStore_.Models
{
    public class Marca
    {
        public int MarcaId { get; set; }
        public string Descricao { get; set; }

        public ICollection<ProductModel>? Products { get; set; }
    }
}
