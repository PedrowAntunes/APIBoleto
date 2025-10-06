using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiBoleto.Data;
using ApiBoleto.Models;
using ApiBoleto.DTOs;

namespace ApiBoleto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BancosController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BancosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanco(BancoCreateDto dto)
        {
            if (string.IsNullOrEmpty(dto.NomeBanco) || string.IsNullOrEmpty(dto.CodigoBanco))
                return BadRequest("Campos obrigatórios ausentes.");

            var banco = new Banco
            {
                NomeBanco = dto.NomeBanco,
                CodigoBanco = dto.CodigoBanco,
                PercentualJuros = dto.PercentualJuros
            };

            _context.Bancos.Add(banco);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBancoByCodigo), new { codigoBanco = banco.CodigoBanco }, banco);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var bancos = await _context.Bancos.ToListAsync();
            return Ok(bancos);
        }

        [HttpGet("{codigoBanco}")]
        public async Task<IActionResult> GetBancoByCodigo(string codigoBanco)
        {
            var banco = await _context.Bancos.FirstOrDefaultAsync(b => b.CodigoBanco == codigoBanco);
            if (banco == null) return NotFound();
            return Ok(banco);
        }
    }
}
