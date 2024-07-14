using APIVoiture.Data;
using APIVoiture.Data.DTOs;
using APIVoiture.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;

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
        var hashedSenha = BCrypt.Net.BCrypt.HashPassword(user.senha);
        user.senha = hashedSenha;
        _context.usuarios.Add(user);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetSingleUser), new {id = user.Id},
        user);
            
    }

    [HttpPost("login")]
    public IActionResult AuthUsuario([FromBody] AuthUsuarioDto authDto)
    {
        if (authDto == null || string.IsNullOrWhiteSpace(authDto.Email) || string.IsNullOrWhiteSpace(authDto.Senha))
        {
            return BadRequest("Dados inválidos.");
        }

        var usuario = _context.usuarios.FirstOrDefault(user => user.email == authDto.Email);
        if (usuario == null || !BCrypt.Net.BCrypt.Verify(authDto.Senha, usuario.senha))
        {
            return Unauthorized("E-mail ou senha incorretos.");
        }

        // Geração do token JWT pode ser feita aqui

        return Ok("Autenticado");
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
    public async Task<ActionResult<IEnumerable<ReadUsuarioDto>>> GetAllUsers()
    {
        var usuarios = _context.usuarios.ToList();
        var readUsuarios = _mapper.Map<List<ReadUsuarioDto>>(usuarios);
        return Ok(readUsuarios);
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
