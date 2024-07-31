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
        public IActionResult AdicionaCinema([FromBody] CreateEnderecoDto cinemaDto)
        {
            Endereco cinema = _mapper.Map<Endereco>(cinemaDto);
            Endereco endere = _context.Enderecos.FirstOrDefault(x => x.CEP == cinemaDto.CEP);
            if (endere == null)
            {
                _context.Enderecos.Add(cinema);
                _context.SaveChanges();
                return CreatedAtAction(nameof(RecuperaCinemasPorId), new { Id = cinema.id }, cinemaDto);
            }
            return Ok(cinema);
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
