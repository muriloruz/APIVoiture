using APIVoiture.Data;
using APIVoiture.Data.DTOs;
using APIVoiture.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace APIVoiture.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private UsuarioContext _context;
    private IMapper _mapper;

    public UsuarioController(UsuarioContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionaUsuario([FromBody] CreateUsuarioDto userDTO)
    {
        Usuario user = _mapper.Map<Usuario>(userDTO);
        _context.usuarios.Add(user);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetSingleUser), new {id = user.Id},
        user);
            
    }

    [HttpGet("single/{id}")]
    public IActionResult GetSingleUser(int id)
    {
        var u = _context.usuarios.FirstOrDefault(user => user.Id == id);
        if(u== null)
            return NotFound();
        var userDto = _mapper.Map<ReadUsuarioDto>(u);
        return Ok(userDto);
    }

    [HttpGet("mult")]
    public IEnumerable<ReadUsuarioDto> GetUsuarioEmMultiplo([FromQuery]int skip=0,[FromQuery] int take = 10)
    {
        return _mapper.Map<List<ReadUsuarioDto>>(_context.usuarios.Skip(skip).Take(take).ToList());
    }
    [HttpGet("all")]
    public IEnumerable<ReadUsuarioDto> GetAllUsers()
    {
        return _mapper.Map<List<ReadUsuarioDto>>(_context.usuarios);
    }

    [HttpPut("{id}")]
    public IActionResult updateUsuario(int id, [FromBody] UpdateUsuarioDto userDto)
    {
        var user = _context.usuarios.FirstOrDefault(user =>user.Id == id);
        if(user == null) return NotFound();
        _mapper.Map(userDto, user);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult updateUsuarioPatch(int id, JsonPatchDocument<UpdateUsuarioDto> patch)
    {
        var user = _context.usuarios.FirstOrDefault(user => user.Id == id);
        if (user == null) return NotFound();

        var usuarioParaAtualizar = _mapper.Map<UpdateUsuarioDto>(user);

        patch.ApplyTo(usuarioParaAtualizar, ModelState);
        if (!TryValidateModel(usuarioParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(usuarioParaAtualizar, user);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult deleteUsuario(int id) {
        var user = _context.usuarios.FirstOrDefault(user => user.Id == id);
        if (user == null) return NotFound();
        _context.Remove(user);
        _context.SaveChanges();
        return NoContent();
    }
}
