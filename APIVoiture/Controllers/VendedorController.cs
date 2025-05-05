using APIVoiture.Data.DTOs;
using APIVoiture.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using APIVoiture.Data;
using APIVoiture.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace APIVoiture.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendedorController : ControllerBase
    {
        private UsuarioContext _context;
        private IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private VendedorServices _vendedorService;

        public VendedorController(UsuarioContext context, IMapper mapper, UserManager<ApplicationUser> userManager, VendedorServices vendedorService)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _vendedorService = vendedorService;

        }

        [HttpPost]
        public async Task<IActionResult> AdicionaVendedor(CreateVendedorDto vendedorDto)
        {
            await _vendedorService.Cadastra(vendedorDto);
            return Ok("Cadastrado!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthVendedor dto)
        {
            var token = await _vendedorService.Login(dto);
            return Ok(token);
        }
        [HttpGet("verEmail/{email}")]
        public async Task<IActionResult> ProcurarEmail(string email)
        {
            var u = await _userManager.FindByEmailAsync(email);
            if (u == null) return NotFound();
            return Ok();
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadVendedorDto>>> RecuperaEnderecos()
        {
            var vend = _context.Vendedor.ToList();
            var readVend = _mapper.Map<List<ReadVendedorDto>>(vend);
            return Ok(readVend);
        }

        [HttpGet("getRole/{id}")]
        public async Task<IActionResult> GetUserRoles(string id)
        {
            var u = await _userManager.FindByIdAsync(id);
            if (u == null)
            {
                return NotFound("Usuario nao localizado");
            }
            var roles = await _userManager.GetRolesAsync(u);
            return Ok(new
            {
                Roles = roles
            });
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaVendedorPorId(string id)
        {
            var vend = _context.Vendedor.FirstOrDefault(user => user.Id == id);
            if (vend == null) return NotFound();
            var vendDto = _mapper.Map<ReadVendedorDto>(vend);
            return Ok(vendDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaVendedor(string id, [FromBody] UpdateVendedorDto vendedorDto)
        {
            Vendedor vendedor = _context.Vendedor.FirstOrDefault(vendedor => vendedor.Id == id);
            if (vendedor == null)
            {
                return NotFound();
            }
            _mapper.Map(vendedorDto, vendedor);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletaVendedor(string id)
        {
            Vendedor vendedor = _context.Vendedor.FirstOrDefault(vendedor => vendedor.Id == id);
            if (vendedor == null)
            {
                return NotFound();
            }
            _context.Remove(vendedor);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
