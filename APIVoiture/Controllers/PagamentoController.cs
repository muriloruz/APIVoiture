using APIVoiture.Data;
using APIVoiture.Data.DTOs;
using APIVoiture.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIVoiture.Controllers;

[Route("[controller]")]
[ApiController]
public class PagamentoController : ControllerBase
{
    private readonly UsuarioContext _context;
    private readonly IMapper _mapper;

    public PagamentoController(UsuarioContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // GET: api/Pagamento
    [HttpGet]
    public ActionResult<IEnumerable<ReadPagamentoDto>> GetPagamentos()
    {
        var pagamentos = _context.Pagamento.ToList();
        return Ok(_mapper.Map<IEnumerable<ReadPagamentoDto>>(pagamentos));
    }

    // GET: api/Pagamento/5
    [HttpGet("{id}")]
    public ActionResult<ReadPagamentoDto> GetPagamento(int id)
    {
        var pagamento = _context.Pagamento.FirstOrDefault(pag => pag.Id == id);
        if (pagamento == null)
        {
            return NotFound();
        }
        return Ok(_mapper.Map<ReadPagamentoDto>(pagamento));
    }

    // POST: api/Pagamento
    [HttpPost]
    public ActionResult<ReadPagamentoDto> CreatePagamento([FromBody] CreatePagamentoDto pagamentoCreateDto)
    {
        var pagamento = _mapper.Map<Pagamento>(pagamentoCreateDto);
        _context.Pagamento.Add(pagamento);
        _context.SaveChanges();

        var pagamentoReadDto = _mapper.Map<ReadPagamentoDto>(pagamento);
        return CreatedAtAction(nameof(GetPagamento), new { id = pagamentoReadDto.Id }, pagamentoReadDto);
    }

    // PUT: api/Pagamento/5
    [HttpPut("{id}")]
    public ActionResult UpdatePagamento(int id, UpdatePagamentoDto pagamentoUpdateDto)
    {
        var pagamento = _context.Pagamento.FirstOrDefault(pag => pag.Id == id);
        if (pagamento == null)
        {
            return NotFound();
        }

        _mapper.Map(pagamentoUpdateDto, pagamento);
        _context.SaveChanges();

        return NoContent();
    }

    // DELETE: api/Pagamento/5
    [HttpDelete("{id}")]
    public ActionResult DeletePagamento(int id)
    {
        var pagamento = _context.Pagamento.FirstOrDefault(pag => pag.Id == id);
        if (pagamento == null)
        {
            return NotFound();
        }

        _context.Pagamento.Remove(pagamento);
        _context.SaveChanges();

        return NoContent();
    }
}