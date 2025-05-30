﻿namespace ProjetoLivros.Dto
{
    public class AtualizarUsuarioDto
    {
        public string NomeCompleto { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string? Telefone { get; set; }

        public DateTime DataAtualizacao { get; set; }

        // Chave estrangeira
        public int TipoUsuarioId { get; set; }
    }
}
