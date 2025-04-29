
using APIVoiture.Data;
using APIVoiture.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIVoiture.Services
{
    public class TokenService
    {
        private IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(ApplicationUser usuario)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("id", usuario.Id.ToString()),
                new Claim("username",usuario.UserName),
                new Claim("nome", usuario.nome),
                
                
            };
            
            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("fjosahfjklashfojsafklgjsaljgnaslghaljhbfljAGDFQRERYTUUOINCNBBMFAGFQIKUFGQAKFKLAQHFKAGFKAGKFJAGKFGVAFKAGFKAGFOQIFOQGFOQGFQ"));

            var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    expires: DateTime.Now.AddDays(5),
                    claims: claims,
                    signingCredentials: signingCredentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateTokenVendedor(ApplicationUser vendedor)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("id", vendedor.Id.ToString()),
                new Claim("username",vendedor.UserName),
                new Claim("nome", vendedor.nome),
                
                
                
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("fjosahfjklashfojsafklgjsaljgnaslghaljhbfljAGDFQRERYTUUOINCNBBMFAGFQIKUFGQAKFKLAQHFKAGFKAGKFJAGKFGVAFKAGFKAGFOQIFOQGFOQGFQ"));

            var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    expires: DateTime.Now.AddDays(5),
                    claims: claims,
                    signingCredentials: signingCredentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}