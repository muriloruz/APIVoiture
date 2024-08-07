using APIVoiture.Data;
using APIVoiture.Data.DTOs;
using APIVoiture.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace APIVoiture.Controllers;

[ApiController]
[Route("[controller]")]
public class PecaController : ControllerBase
{
    private UsuarioContext _context;
    private IMapper _mapper;

    public PecaController(UsuarioContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    [HttpPost]
    public ActionResult<ReadPecaDto> CreatePagamento([FromBody] CreatePecaDto pecaCreateDto)
    {
        var peca = _mapper.Map<Peca>(pecaCreateDto);
        _context.Pecas.Add(peca);
        _context.SaveChanges();

        var pecaReadDto = _mapper.Map<ReadPecaDto>(peca);
        return CreatedAtAction(nameof(GetPeca), new { id = pecaReadDto.Id }, pecaReadDto);
    }
    [HttpGet]
    public ActionResult<IEnumerable<ReadPecaDto>> GetPecas()
    {
        var peca = _context.Pecas.ToList();
        return Ok(_mapper.Map<IEnumerable<ReadPecaDto>>(peca));   
    }
    [HttpGet("/{id}")]
    public ActionResult<ReadPecaDto> GetPeca(int id)
    {
        var p = _context.Pecas.FirstOrDefault(peca => peca.Id == id);
        if(p == null)
            return NotFound();
        return Ok(_mapper.Map<ReadPecaDto>(p));
    }
    [HttpPatch("/{id}")]
    public IActionResult updatePecaPatch(int id, JsonPatchDocument<UpdatePecaDto> patch)
    {
        var peca = _context.Pecas.FirstOrDefault(peca => peca.Id == id);
        if (peca == null) return NotFound();

        var pecaParaAtualizar = _mapper.Map<UpdatePecaDto>(peca);

        patch.ApplyTo(pecaParaAtualizar, ModelState);
        if (!TryValidateModel(pecaParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(pecaParaAtualizar, peca);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpDelete("/{id}")]
    public ActionResult DeletePeca(int id) { 
        var p = _context.Pecas.FirstOrDefault(peca => peca.Id == id);
        if(p==null) return NotFound();
        _context.Pecas.Remove(p);
        _context.SaveChanges();
        return NoContent();
    }
}

