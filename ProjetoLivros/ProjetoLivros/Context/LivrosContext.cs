using Microsoft.EntityFrameworkCore;
using ProjetoLivros.Models;

namespace ProjetoLivros.Context
{
    // Todo Contexto Herda da classe DbContext (padrao do EntityFramework) (Classe feita para trabalhar com Banco de Dados)
    public class LivrosContext : DbContext
    {
        // Cada Tabela -> DbSet
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<TipoUsuario> TipoUsuarios { get; set; }

        public DbSet<Assinatura> Assinaturas { get; set; }

        public DbSet<Livro> Livros { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        // ctor + tab = Metodo Contrutor (linha abaico)
        // Acessa a base do Banco de dados e retorna para o contexto
        public LivrosContext(DbContextOptions<LivrosContext> options) : base(options) { }

        // Cria a conexao com o Banco de Dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // String de conecao
            optionsBuilder.UseSqlServer("Data Source=NOTE04-S28\\SQLEXPRESS;Initial Catalog=Livros;User Id=sa;Password=Senai@134;TrustServerCertificate=true;");
        }

        // Define os "tipos" do banco de dados, limites de cacteres
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Definir os dados que o banco de Dados ira recber
            modelBuilder.Entity<Usuario>(
                // Representacao da tabela
                entity =>
                {
                    //  Como definir a Primary Key
                    entity.HasKey(u => u.UsuarioId);

                    // Configurando o campo, para definir oq ele e e quantos e quais tipos de caracteres ele ira aceitar
                    entity.Property(u => u.NomeCompleto)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false); // Desabilita o Unicode, o Unicode vem por padrao habilitado, se deixar ele habilitado o VARCHAR vira NVARCHAR, que aceita todos os alfabetos existentes, que por consequencia gasta muito mais espaco

                    // Configurando o campo, para definir oq ele e e quantos e quais tipos de caracteres ele ira aceitar
                    entity.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode (false);

                    // Deixar o Email unico
                    entity.HasIndex(u => u.Email)
                    .IsUnique();

                    // Configurando o campo, para definir oq ele e e quantos e quais tipos de caracteres ele ira aceitar
                    entity.Property(u => u.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode (false);

                    // Configurando o campo, para definir oq ele e e quantos e quais tipos de caracteres ele ira aceitar
                    entity.Property(u => u.Telefone)
                    .IsUnicode(false);

                    // Configurando o campo, para definir oq ele e e quantos e quais tipos de caracteres ele ira aceitar
                    entity.Property(u => u.DataCadastro)
                    .IsRequired();

                    // Configurando o campo, para definir oq ele e e quantos e quais tipos de caracteres ele ira aceitar
                    entity.Property(u => u.DataAtualizacao)
                    .IsRequired();

                    // Configurando o Relacionamento entre as tabelas Usuarios e TipoUsuario 1 : N
                    entity.HasOne(u => u.TipoUsuario)
                    .WithMany(t => t.Usuarios)
                    .HasForeignKey(u => u.TipoUsuario) // Configurando a Chave estrangeira
                    .OnDelete(DeleteBehavior.Cascade); // Permite apagar os dados da tabela TipoUsuario, e quando apagar vai apagar todos os Clientes que tem esse tipo de Usuario
                }
            );
        }
    }
}
