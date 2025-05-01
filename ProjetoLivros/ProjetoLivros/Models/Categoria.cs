namespace ProjetoLivros.Models
{
    public class Categoria
    {
        // prop+tab = Cria uma propiedade (linha abaixo)
        public int CategoriaId { get; set; }
        public string NomeCategoria { get; set; }

        // Navegacao entre Categoria e Livros, Para listar os Livros pela tabela Categoria
        public List<Livro> Livros { get; set; }
    }
}
