using APIVoiture.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIVoiture.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private static List<Usuario> users = new List<Usuario>();
    private static int id = 0;
    [HttpPost]
    public IActionResult AdicionaUsuario([FromBody] Usuario user)
    {
        user.Id = id++;
        users.Add(user);
        return CreatedAtAction(nameof(GetSingleUser), new {id = user.Id},
        user);
            
    }
    [HttpGet("single/{id}")]
    public IActionResult GetSingleUser(int id)
    {
        var u = users.FirstOrDefault(user => user.Id == id);
        if(u== null)
            return NotFound();
        return Ok(u);
    }
    [HttpGet("mult")]
    public IEnumerable<Usuario> GetUsuarioEmMultiplo([FromQuery]int skip=0,[FromQuery] int take = 10)
    {
        return users.Skip(skip).Take(take).ToList();
    }
    [HttpGet("all")]
    public IEnumerable<Usuario> GetAllUsers()
    {
        return users;
    }
}
