namespace ProjetoLivros.Models
{
    public class Livro
    {
        // prop+tab = Cria uma propiedade (linha abaixo)
        public int LivroId { get; set; }

        public string Titulo { get; set; }

        public string Autor { get; set; }

        public string? Descricao { get; set; }

        public DateTime DataPublicacao { get; set; }

        // Chave estrangeira
        public int CategoriaId { get; set; }

        // Lista a tabela Categoria <-> Cria a navegacao entre elas
        public Categoria? Categoria { get; set; }
    }
}
