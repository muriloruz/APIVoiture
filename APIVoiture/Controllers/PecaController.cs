using APIVoiture.Data;
using APIVoiture.Data.DTOs;
using APIVoiture.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    
   public ActionResult<ReadPecaDto> CreatePeca([FromForm] CreatePecaDto pecaCreateDto)
    {
        var peca = _mapper.Map<Peca>(pecaCreateDto);
        if (pecaCreateDto.imagem != null && pecaCreateDto.imagem.Length > 0) // Adicione verificação de tamanho
        {
            var caminho = Path.Combine("wwwroot/imagens", pecaCreateDto.imagem.FileName);
            using (var stream = new FileStream(caminho, FileMode.Create))
            {
                pecaCreateDto.imagem.CopyTo(stream); // Copia o conteúdo do arquivo para o stream
            }
            peca.imagem = pecaCreateDto.imagem.FileName;
        }
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
    [HttpGet("{nome}")]
    public ActionResult<IEnumerable<ReadPecaDto>> GetPeca(string nome)
    {
        var pecas = _context.Pecas
        .Where(peca => peca.nomePeca.Contains(nome.ToLower()))
        .ToList();
        if (!pecas.Any())
            return NotFound();
        return Ok(_mapper.Map<IEnumerable<ReadPecaDto>>(pecas));
    }
    [HttpPatch("/{id}")]
    [Authorize(Policy = "VendedorPolicy")]
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
    [HttpGet("{id:int}")]
    public ActionResult<ReadPecaDto> GetPeca(int id)
    {
        var peca = _context.Pecas.FirstOrDefault(p => p.Id == id);
        if (peca == null)
        {
            return NotFound();
        }
        return Ok(_mapper.Map<ReadPecaDto>(peca));
    }
    [HttpDelete("/{id}")]
    [Authorize(Policy = "VendedorPolicy")]
    public ActionResult DeletePeca(int id) { 
        var p = _context.Pecas.FirstOrDefault(peca => peca.Id == id);
        if(p==null) return NotFound();
        _context.Pecas.Remove(p);
        _context.SaveChanges();
        return NoContent();
    }
}

