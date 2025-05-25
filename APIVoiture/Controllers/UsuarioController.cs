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
    private UserManager<ApplicationUser> _userManager;
    private UsuarioServices _usuarioService;

    public UsuarioController(UsuarioContext context, IMapper mapper, UserManager<ApplicationUser> userManager, UsuarioServices cadastroService)
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
        try
        {
            var token = await _usuarioService.Login(dto);
            return Ok(token);
        }
        catch (ApplicationException ex)
        {
            return  NotFound(ex.Message);
        }
        
    }
    [HttpGet("getRole/{id}")]
    public async Task<IActionResult> GetUserRoles(string id)
    {
        var u = await _userManager.FindByIdAsync(id);
        if(u == null)
        {
            return NotFound("Usuario nao localizado");
        }
        var roles = await _userManager.GetRolesAsync(u);
        return Ok(new
        {
            Roles = roles
        });
    }
    [HttpPost("verEmail")]
    public async Task<IActionResult> verificarEmail(DtoEmailCNPJ dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user == null) return NotFound("Email não encontrado.");

        var usuario = await _context.usuarios.FirstOrDefaultAsync(v => v.CPF == dto.CNPJ && v.Id == user.Id);

        if (usuario == null) return NotFound("CPF não está vinculado ao email informado.");

        return Ok(user.Id);
    }
    [HttpGet("users/{id}")]
    public async Task<IActionResult> GetUser(string id)
    {
        var u = await _context.usuarios.FirstOrDefaultAsync(user => user.Id ==id);
        var v = await _context.Vendedor.FirstOrDefaultAsync(vend => vend.Id ==id);

        if (u == null && v == null)
        {
            return NotFound();
        }
        else if (v == null) {
            var userDto = _mapper.Map<ReadUsuarioDto>(u);
            return Ok(userDto);
        }
        var vendDto = _mapper.Map<ReadVendedorDto>(v);
        return Ok(vendDto);
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
    public IActionResult updateUsuarioPatch(string id,[FromBody] JsonPatchDocument<UpdateUsuarioDto> patch)
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
    [HttpPost("password/{id}")]
    public async Task<IActionResult> ChangePassword(string id, [FromBody] ChangePasswordRequest dto)
    {

        var result = await _usuarioService.Recupera(id, dto.NewPassword);

        if (result.Succeeded) {
            return Ok();
        }
        return BadRequest();
    }

}
