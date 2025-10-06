namespace ApiBoleto.DTOs
{
    public class BancoCreateDto
    {
        public string NomeBanco { get; set; } = null!;
        public string CodigoBanco { get; set; } = null!;
        public decimal PercentualJuros { get; set; }
    }
}
namespace ApiBoleto.DTOs
{
    public class BoletoCreateDto
    {
        public string NomePagador { get; set; } = null!;
        public string CpfCnpjPagador { get; set; } = null!;
        public string NomeBeneficiario { get; set; } = null!;
        public string CpfCnpjBeneficiario { get; set; } = null!;
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public string? Observacao { get; set; }
        public int BancoId { get; set; }
    }
}
