namespace ProjetoLivros.ViewModels
{
    public class ListarUsuarioViewModel
    {
        // prop+tab = Cria uma propiedade (linha abaixo)
        public int UsuarioId { get; set; }

        public string NomeCompleto { get; set; }

        public string Email { get; set; }

        public string? Telefone { get; set; }

        public DateTime DataCadastro { get; set; }

        // Chave estrangeira
        public int TipoUsuarioId { get; set; }
    }
}
