using APIVoiture.Data;
using APIVoiture.Data.DTOs;
using APIVoiture.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIVoiture.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendedorClienteController : ControllerBase
    {
            private readonly UsuarioContext _context;
            private IMapper _mapper;

            public VendedorClienteController(UsuarioContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            // GET api/vendedorcliente
            [HttpGet]
            public IEnumerable<VendedorClienteDTO> GetVendedorClientes()
            {
                return _mapper.Map<List<VendedorClienteDTO>>(_context.VendedorClientes.ToList());
            }
            [HttpGet("{usuarioId}/{vendedorId}")]
            public IActionResult GetById(string usuarioId, string vendedorId)
            {
                VendedorCliente vc = _context.VendedorClientes.FirstOrDefault(vc => vc.UsuarioId == usuarioId && vc.VendedorId == vendedorId);
                if (vc != null)
                {
                    VendedorClienteDTO vcDTO = _mapper.Map<VendedorClienteDTO>(vc);
                    return Ok(vcDTO);
                }
                return NotFound();
            }
            // POST api/vendedorcliente
            [HttpPost]
            public IActionResult CreateVendedorCliente(VendedorClienteDTO vendedorClienteDTO)
            {
                VendedorCliente vc = _mapper.Map<VendedorCliente>(vendedorClienteDTO);
                _context.VendedorClientes.Add(vc);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetById), new { usuarioId = vc.UsuarioId, vc.VendedorId }, vc);

            }

            // DELETE api/vendedorcliente/5
            [HttpDelete("{id}")]
            public async Task<ActionResult> DeleteVendedorCliente(int id)
            {
                var vendedorCliente = await _context.VendedorClientes.FindAsync(id);
                if (vendedorCliente == null)
                {
                    return NotFound();
                }
                _context.VendedorClientes.Remove(vendedorCliente);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }
    }
