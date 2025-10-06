using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiBoleto.Data;
using ApiBoleto.Models;
using ApiBoleto.DTOs;

namespace ApiBoleto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoletosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BoletosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBoleto(BoletoCreateDto dto)
        {
            if (string.IsNullOrEmpty(dto.NomePagador) || string.IsNullOrEmpty(dto.CpfCnpjPagador) ||
                string.IsNullOrEmpty(dto.NomeBeneficiario) || string.IsNullOrEmpty(dto.CpfCnpjBeneficiario) ||
                dto.Valor <= 0 || dto.BancoId == 0)
                return BadRequest("Campos obrigatórios ausentes ou inválidos.");

            var banco = await _context.Bancos.FindAsync(dto.BancoId);
            if (banco == null) return BadRequest("Banco não encontrado.");

            var boleto = new Boleto
            {
                NomePagador = dto.NomePagador,
                CpfCnpjPagador = dto.CpfCnpjPagador,
                NomeBeneficiario = dto.NomeBeneficiario,
                CpfCnpjBeneficiario = dto.CpfCnpjBeneficiario,
                Valor = dto.Valor,
                DataVencimento = dto.DataVencimento,
                Observacao = dto.Observacao ?? "",
                BancoId = dto.BancoId
            };

            _context.Boletos.Add(boleto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBoletoById), new { id = boleto.Id }, boleto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBoletoById(int id)
        {
            var boleto = await _context.Boletos.Include(b => b.Banco).FirstOrDefaultAsync(b => b.Id == id);
            if (boleto == null) return NotFound();

            // Se vencido, aplica juros total
            if (boleto.DataVencimento < DateTime.UtcNow)
            {
                boleto.Valor += boleto.Valor * (boleto.Banco.PercentualJuros / 100);
            }

            return Ok(boleto);
        }
    }
}
