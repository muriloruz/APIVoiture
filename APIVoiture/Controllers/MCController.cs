using AutoMapper;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using APIVoiture.Data;
using APIVoiture.Data.DTOs;
using APIVoiture.Models;

namespace APIVoiture.Controllers;

[ApiController]
[Route("[controller]")]
public class MCController : ControllerBase
{
        private UsuarioContext _context;
        private IMapper _mapper;

        public MCController(UsuarioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaSessao(CreateMCDto dto)
        {
            ModeloCarro sessao = _mapper.Map<ModeloCarro>(dto);
            _context.ModeloCarros.Add(sessao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaSessoesPorId), new { Id = sessao.id }, sessao);
        }

        [HttpGet]
        public IEnumerable<ReadMCDto> RecuperaSessoes()
        {
            return _mapper.Map<List<ReadMCDto>>(_context.ModeloCarros.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessoesPorId(int id)
        {
            ModeloCarro sessao = _context.ModeloCarros.FirstOrDefault(sessao => sessao.id == id);
            if (sessao != null)
            {
                ReadMCDto sessaoDto = _mapper.Map<ReadMCDto>(sessao);

                return Ok(sessaoDto);
            }
            return NotFound();
        }
    }
