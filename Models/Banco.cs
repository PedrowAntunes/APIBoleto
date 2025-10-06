using System.ComponentModel.DataAnnotations;

namespace ApiBoleto.Models
{
    public class Banco
    {
        public int Id { get; set; }
        [Required]
        public string NomeBanco { get; set; }
        [Required]
        public string CodigoBanco { get; set; }
        [Required]
        public decimal PercentualJuros { get; set; }
        public List<Boleto> Boletos { get; set; }
    }
}
