using System.ComponentModel.DataAnnotations;

namespace WebApi2.Models
{
    public class Produto
    {
        public int Id {  get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        [Required]
        [StringLength(8, ErrorMessage = "O tamanho máximo do código é 8 caracteres.")]
        public string? Codigo { get; set; }
        [Range(10, 5000, ErrorMessage = "O preço deve estar entre 10 e 5000.")]
        public decimal preco { get; set; }
    }
}
