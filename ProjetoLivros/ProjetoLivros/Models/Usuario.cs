namespace ProjetoLivros.Models
{
    public class Usuario
    {
        // prop+tab = Cria uma propiedade (linha abaixo)
        public int UsuarioId { get; set; }

        public string NomeCompleto { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string? Telefone { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataAtualizacao { get; set; }

        // Chave estrangeira
        public int TipoUsuarioId { get; set; }

        // Lista a tabela TipoUsuario <-> Cria a navegacao entre elas
        public TipoUsuario? TipoUsuario { get; set; }
    }
}
