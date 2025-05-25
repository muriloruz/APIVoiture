using APIVoiture.Data;
using APIVoiture.Data.DTOs;
using APIVoiture.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIVoiture.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FavoritoController : ControllerBase

    {
        private readonly UsuarioContext _context;
        private IMapper _mapper;

        public FavoritoController(UsuarioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CriarFavorito(FavoritoDTO dto)
        {
            
            bool existe = await _context.Favorito.AnyAsync(f => f.UserId == dto.UserId && f.PecaId == dto.PecaId);
            if (existe) {
                return Ok("Peça já favoritada");
            }
            Favorito fav = _mapper.Map<Favorito>(dto);
            _context.Favorito.Add(fav);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(CriarFavorito), new { id = fav.Id }, fav);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFavoritosUser(string id)
        {
            var lista = await _context.Favorito
                .Where(f => f.UserId == id)
                .Select(f => new
                {
                    f.Id,
                    f.PecaId,
                    NomePeca = f.Peca.nomePeca,
                    Descricao = f.Peca.descricao,
                    Imagem = f.Peca.imagem,
                    Preco = f.Peca.preco,
                })
                .ToListAsync();

            if(!lista.Any()) return NotFound("Nenhuma Peça favorita encontrada");

            return Ok(lista);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeletarFavoritos(int id) { 
            var fav  = await _context.Favorito.FindAsync(id);
            if (fav == null) return NotFound();
            _context.Favorito.Remove(fav);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
