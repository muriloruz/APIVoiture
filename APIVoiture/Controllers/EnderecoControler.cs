using APIVoiture.Data;
using APIVoiture.Data.DTOs;
using APIVoiture.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace APIVoiture.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class EnderecoController : ControllerBase
    {
        private UsuarioContext _context;
        private IMapper _mapper;

        public EnderecoController(UsuarioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            Endereco endere = _context.Enderecos.FirstOrDefault(x => x.CEP == enderecoDto.CEP);
            if (endere == null)
            {
                _context.Enderecos.Add(endereco);
                _context.SaveChanges();
                return Ok(endereco.id);
            }
            return Ok(endere.id);
        }

        [HttpGet]
        public IEnumerable<ReadEnderecoDto> RecuperaCinemas()
        {
            return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemasPorId(int id)
        {
            Endereco cinema = _context.Enderecos.FirstOrDefault(cinema => cinema.id == id);
            if (cinema != null)
            {
                ReadEnderecoDto cinemaDto = _mapper.Map<ReadEnderecoDto>(cinema);
                return Ok(cinemaDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateEnderecoDto cinemaDto)
        {
            Endereco cinema = _context.Enderecos.FirstOrDefault(cinema => cinema.id == id);
            if (cinema == null)
            {
                return NotFound();
            }
            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            Endereco cinema = _context.Enderecos.FirstOrDefault(cinema => cinema.id == id);
            if (cinema == null)
            {
                return NotFound();
            }
            _context.Remove(cinema);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
