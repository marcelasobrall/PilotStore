using System;
using System.ComponentModel.DataAnnotations;

namespace PilotStore_.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        public string Description { get; set; }

        public bool IsActive { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double Price { get; set; }



        [Display(Name = "Data de Lançamento")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Imagem do Produto")]
        public string ImagePath { get; set; }

        [Display(Name = "Marca")]
        public int? MarcaId { get; set; }

        public string GenerateSlug()
        {
            string slug = Name?.ToLower().Replace(" ", "-").Replace(".", "").Replace(",", "") ?? string.Empty;
            return Uri.EscapeUriString(slug); 
        }
    }
}
