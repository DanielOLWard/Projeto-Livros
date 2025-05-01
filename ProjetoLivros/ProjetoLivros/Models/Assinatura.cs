namespace ProjetoLivros.Models
{
    public class Assinatura
    {
        // prop+tab = Cria uma propiedade (linha abaixo)
        public int AssinaturaId { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public string Status { get; set; }

        // Chave estrangeira
        public int UsuarioId { get; set; }

        // Lista a tabela Usuario <-> Cria a navegacao entre elas
        public Usuario? Usuario { get; set; }
    }
}
