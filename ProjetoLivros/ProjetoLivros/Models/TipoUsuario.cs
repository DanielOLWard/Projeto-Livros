namespace ProjetoLivros.Models
{
    public class TipoUsuario
    {
        // prop+tab = Cria uma propiedade (linha abaixo)
        public int TipoUsuarioId { get; set; }

        public string DescricaoTipo { get; set; }

        // Navegacao entre TipoUsuario e Usuario, Para listar os Usuarios na tabela TipoUsuario
        public List<Usuario> Usuarios { get; set; } = new();
    }
}
