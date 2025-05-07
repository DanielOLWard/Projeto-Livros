using Microsoft.AspNetCore.Identity;
using ProjetoLivros.Models;

namespace ProjetoLivros.Services
{
    public class PasswordService
    {
        private readonly PasswordHasher<Usuario> _hasher = new();

        // 1 - Gerar um Hash
        public string HashPassword(Usuario usuario)
        {
            return _hasher.HashPassword(usuario, usuario.Senha);
        }

        // 2 - Verificar o hash
        public bool VerificarSenha(Usuario usuario, string senhaInformada)
        {
            var resultado = _hasher.VerifyHashedPassword(usuario, usuario.Senha, senhaInformada);
            return resultado == PasswordVerificationResult.Success;
        }
    }
}
