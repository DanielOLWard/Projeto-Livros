using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ProjetoLivros.Services
{
    public class TokenService
    {
        public string GerarToken(string email)
        {
            // claims - Informacoes do usuario que eu desejo guardar
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email)
            };

            // Criar uma Chave de seguranca
            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("minha-chave-ultra-mega-blaster-super-secreta-de-seguranca-so-senai")); // a chave tem que ser grande pois se for muito pequena vai da erro

            // Criptrografo a Chave de Seguranca
            var creds = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            // Montar o Token
            var token = new JwtSecurityToken(
                issuer: "livros", // Issuer e Audience tem que ter o mesmo nome
                audience: "livros",
                claims: claims, // O email e guardado aqui
                expires: DateTime.Now.AddMinutes(20), // Tempo de expiracao do Token, Nao Deixar mais de 60 minutos
                signingCredentials: creds // chave de seguranca
            );

            // Retorno o token recem criado e valido ele
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
