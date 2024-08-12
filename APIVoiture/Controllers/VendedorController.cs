using APIVoiture.Data.DTOs;
using APIVoiture.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using APIVoiture.Data;

namespace APIVoiture.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendedorController : ControllerBase
    {
        private UsuarioContext _context;
        private IMapper _mapper;

        public VendedorController(UsuarioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaVendedor([FromBody] CreateVendedorDto vendedorDto)
        {
            Vendedor vendedor = _mapper.Map<Vendedor>(vendedorDto);
            _context.Vendedor.Add(vendedor);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaVendedorPorId), new { Id = vendedor.Id }, vendedor);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadVendedorDto>>> RecuperaEnderecos()
        {
            var vend = _context.Vendedor.ToList();
            var readVend = _mapper.Map<List<ReadVendedorDto>>(vend);
            return Ok(readVend);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaVendedorPorId(string id)
        {
            Vendedor vendedor = _context.Vendedor.FirstOrDefault(vendedor => vendedor.Id == id);
            if (vendedor != null)
            {
                ReadVendedorDto vendedorDto = _mapper.Map<ReadVendedorDto>(vendedor);

                return Ok(vendedorDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaVendedor(string id, [FromBody] UpdateVendedorDto vendedorDto)
        {
            Vendedor vendedor = _context.Vendedor.FirstOrDefault(vendedor => vendedor.Id == id);
            if (vendedor == null)
            {
                return NotFound();
            }
            _mapper.Map(vendedorDto, vendedor);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaVendedor(string id)
        {
            Vendedor vendedor = _context.Vendedor.FirstOrDefault(vendedor => vendedor.Id == id);
            if (vendedor == null)
            {
                return NotFound();
            }
            _context.Remove(vendedor);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
