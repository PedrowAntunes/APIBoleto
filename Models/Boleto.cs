using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiBoleto.Models
{
    public class Boleto
    {
        public int Id { get; set; }
        [Required]
        public string NomePagador { get; set; }
        [Required]
        public string CpfCnpjPagador { get; set; }
        [Required]
        public string NomeBeneficiario { get; set; }
        [Required]
        public string CpfCnpjBeneficiario { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public DateTime DataVencimento { get; set; }
        public string Observacao { get; set; }
        [Required]
        public int BancoId { get; set; }

        [ForeignKey("BancoId")]
        public Banco Banco { get; set; }
    }
}
