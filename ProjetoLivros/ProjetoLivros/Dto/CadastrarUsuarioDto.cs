﻿namespace ProjetoLivros.Dto
{
    public class CadastrarUsuarioDto
    {
        public string NomeCompleto { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string? Telefone { get; set; }

        public DateTime DataCadastro { get; set; }

        // Chave estrangeira
        public int TipoUsuarioId { get; set; }
    }
}
