using APIVoiture.Data;
using APIVoiture.Data.DTOs;
using APIVoiture.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIVoiture.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendedorClienteController : ControllerBase
    {
            private readonly UsuarioContext _context;
            private IMapper _mapper;

            public VendedorClienteController(UsuarioContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            [HttpGet]
            public IEnumerable<VendedorClienteDTO> GetVendedorClientes()
            {
                return _mapper.Map<List<VendedorClienteDTO>>(_context.VendedorClientes.ToList());
            }
            [HttpGet("{usuarioId}")]
            public IActionResult GetById(string usuarioId)
            {
                VendedorCliente vc = _context.VendedorClientes.FirstOrDefault(vc => vc.UsuarioId == usuarioId);
                if (vc != null)
                {
                    VendedorClienteDTO vcDTO = _mapper.Map<VendedorClienteDTO>(vc);
                    return Ok(vcDTO);
                }
                return NotFound();
            }
            
            [HttpPost]
            public IActionResult CreateVendedorCliente(VendedorClienteDTO vendedorClienteDTO)
            {
                VendedorCliente vc = _mapper.Map<VendedorCliente>(vendedorClienteDTO);
                _context.VendedorClientes.Add(vc);
                _context.SaveChanges();
                return CreatedAtAction(nameof(GetById), new { usuarioId = vc.UsuarioId, vc.VendedorId }, vc);

            }
            [HttpGet("pecas/{nome}")]
            public ActionResult<IEnumerable<object>> GetPeca(string nome)
            {
                var pecas = _context.VendedorClientes
                    .Include(vc => vc.Peca)
                    .Where(vc => vc.Peca.nomePeca.ToLower().Contains(nome.ToLower()))
                    .Select(vc => vc.Peca)
                    .Distinct()
                    .ToList();

                if (!pecas.Any())
                    return NotFound();

                var pecasDto = _mapper.Map<IEnumerable<ReadPecaDto>>(pecas);

                var resposta = pecasDto.Select(p => new {
                    peca = p
                });

                return Ok(resposta);
            }

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
