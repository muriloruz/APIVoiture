using APIVoiture.Data;
using APIVoiture.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIVoiture.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private UsuarioContext _context;

    public UsuarioController(UsuarioContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AdicionaUsuario([FromBody] Usuario user)
    {
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
        return Ok(u);
    }
    [HttpGet("mult")]
    public IEnumerable<Usuario> GetUsuarioEmMultiplo([FromQuery]int skip=0,[FromQuery] int take = 10)
    {
        return _context.usuarios.Skip(skip).Take(take).ToList();
    }
    [HttpGet("all")]
    public IEnumerable<Usuario> GetAllUsers()
    {
        return _context.usuarios;
    }
}
