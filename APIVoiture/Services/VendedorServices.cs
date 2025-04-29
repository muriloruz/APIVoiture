using APIVoiture.Data;
using APIVoiture.Data.DTOs;
using APIVoiture.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace APIVoiture.Services
{
    public class VendedorServices
    {
        private IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly TokenService _tokenService;

        public VendedorServices(IMapper mapper, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, TokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }





        public async Task Cadastra(CreateVendedorDto userDTO)
        {
            Vendedor usuario = _mapper.Map<Vendedor>(userDTO);
            
                var re = await _userManager.CreateAsync(usuario, userDTO.Password);
                await _userManager.AddToRoleAsync(usuario, "Vendedor");
                if (!re.Succeeded)
                {
                    throw new ApplicationException("Falha ao cadastrar!");
                }

            




        }

        public async Task<string> Login(AuthVendedor dto)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(dto.UserName);
            if (user != null)
            {
                var re = await _signInManager.PasswordSignInAsync(user.UserName, dto.Password, false, false);
                if (!re.Succeeded)
                {
                    throw new ApplicationException("Deu ruim");
                }
                var usuario = _signInManager.UserManager.Users.FirstOrDefault(x => x.NormalizedUserName == dto.UserName.ToUpper());
                return _tokenService.GenerateTokenVendedor(usuario);

            }
            else
            {
                throw new ApplicationException("Email não encontrado");
            }
        }
    }
}
