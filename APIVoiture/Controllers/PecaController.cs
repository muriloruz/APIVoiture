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
    private readonly IWebHostEnvironment _env;

    public PecaController(UsuarioContext context, IMapper mapper, IWebHostEnvironment env)
    {
        _context = context;
        _mapper = mapper;
        _env = env;
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
    [HttpPatch("{id}")]
    public IActionResult UpdatePeca([FromForm] UpdatePecaDto updatePecaDto, int id)
    {
        var pecaExistente = _context.Pecas.FirstOrDefault(peca => peca.Id == id);
        if (pecaExistente == null) return NotFound();

        pecaExistente.nomePeca = updatePecaDto.NomePeca;
        pecaExistente.descricao = updatePecaDto.Descricao;
        pecaExistente.garantia = updatePecaDto.Garantia;
        pecaExistente.fabricante = updatePecaDto.Fabricante;
        pecaExistente.qntd = updatePecaDto.Qntd.Value;
        pecaExistente.preco = updatePecaDto.Preco.Value;

        if (updatePecaDto.Imagem != null && updatePecaDto.Imagem.Length > 0)
        {
            if (!string.IsNullOrEmpty(pecaExistente.imagem))
            {
                var oldImagePath = Path.Combine(_env.WebRootPath, "imagens", pecaExistente.imagem);
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }

            var uploadsFolder = Path.Combine(_env.WebRootPath, "imagens");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + updatePecaDto.Imagem.FileName;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                updatePecaDto.Imagem.CopyTo(fileStream);
            }
            pecaExistente.imagem = uniqueFileName;
        }

        _context.Pecas.Update(pecaExistente);
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
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePeca(int id) { 
        var p = _context.Pecas.FirstOrDefault(peca => peca.Id == id);
        if(p==null) return NotFound();
        if (p.qntd > 1)
        {
            p.qntd -= 1;
            await _context.SaveChangesAsync();
            return Ok(p);
        }
        _context.Pecas.Remove(p);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpDelete("apagar/{id:int}")]
    public async Task<IActionResult> ApagarPeca(int id)
    {
        var p = _context.Pecas.FirstOrDefault(peca => peca.Id == id);
        if (p == null) return NotFound();
        _context.Pecas.Remove(p);
        _context.SaveChanges();
        return NoContent();
    }
}

