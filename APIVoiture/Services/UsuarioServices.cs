using APIVoiture.Data.DTOs;
using APIVoiture.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace APIVoiture.Services;

public class UsuarioServices
{
    private IMapper _mapper;
    private UserManager<Usuario> _userManager;
    private SignInManager<Usuario> _signInManager;
    private TokenService _tokenService;

    public UsuarioServices(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, TokenService tokenService)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }





    public async Task Cadastra(CreateUsuarioDto userDTO)
    {
        Usuario usuario = _mapper.Map<Usuario>(userDTO);
        var re = await _userManager.CreateAsync(usuario, userDTO.Password);
        if (!re.Succeeded)
        {
            throw new ApplicationException("Falha ao cadastrar!");
        }
       
    }

    public async Task<string> Login(AuthUsuarioDto dto)
    {
        Usuario user = await _userManager.FindByEmailAsync(dto.Email);
        if (user != null)
        {
            var re = await _signInManager.PasswordSignInAsync(user.UserName, dto.Password, false, false);
            if (!re.Succeeded)
            {
                throw new ApplicationException("Deu ruim");
            }
            var usuario = _signInManager.UserManager.Users.FirstOrDefault(x => x.NormalizedUserName == dto.Email.ToUpper());
            return _tokenService.GenerateToken(usuario);

        }
        else
        {
            throw new ApplicationException("Email não encontrado");
        }
    }




}
