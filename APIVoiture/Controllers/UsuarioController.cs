using APIVoiture.Data;
using APIVoiture.Data.DTOs;
using APIVoiture.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using APIVoiture.Services;

namespace APIVoiture.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    
    private UsuarioContext _context;
    private IMapper _mapper;
    private UserManager<Usuario> _userManager;
    private UsuarioServices _usuarioService;

    public UsuarioController(UsuarioContext context, IMapper mapper, UserManager<Usuario> userManager, UsuarioServices cadastroService)
    {
        _context = context;
        _mapper = mapper;
        _userManager = userManager;
        _usuarioService = cadastroService;
    }

    [HttpPost]
    public async Task<IActionResult> AdicionaUsuario(CreateUsuarioDto userDTO)
    {
        await _usuarioService.Cadastra(userDTO);
        return Ok("Cadastrado!");
            
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login(AuthUsuarioDto dto)
    {
        var token = await _usuarioService.Login(dto);
        return Ok(token);
    }


    [HttpGet("single/{id}")]
    public IActionResult GetSingleUser(string id)
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
    public IActionResult updateUsuario(string id, [FromBody] UpdateUsuarioDto userDto)
    {
        var user = _context.usuarios.FirstOrDefault(user =>user.Id == id);
        if(user == null) return NotFound();
        _mapper.Map(userDto, user);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult updateUsuarioPatch(string id, JsonPatchDocument<UpdateUsuarioDto> patch)
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
    public IActionResult deleteUsuario(string id) {
        var user = _context.usuarios.FirstOrDefault(user => user.Id == id);
        if (user == null) return NotFound();
        _context.Remove(user);
        _context.SaveChanges();
        return NoContent();
    }
}
