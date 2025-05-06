using Microsoft.EntityFrameworkCore;
using ProjetoLivros.Models;

namespace ProjetoLivros.Context
{
    // Todo Contexto Herda da classe DbContext (padrao do EntityFramework) (Classe feita para trabalhar com Banco de Dados)
    public class LivrosContext : DbContext
    {
        // DbSet <-> Cada linha e uma Tabela no banco de dados
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
            // String de conecao com o bd
            optionsBuilder.UseSqlServer("Data Source=NOTE04-S28\\SQLEXPRESS;Initial Catalog=Livros;User Id=sa;Password=Senai@134;TrustServerCertificate=true;");
        }

        // Define os "tipos" do banco de dados, limites de cacteres
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Definir os dados que o banco de Dados ira recber
            modelBuilder.Entity<Usuario>(entity =>
            {
                //  Como definir a Primary Key
                entity.HasKey(u => u.UsuarioId);

                // Configurando o campo, para definir oq ele e e quantos e quais tipos de caracteres ele ira aceitar
                entity.Property(u => u.NomeCompleto)
                .IsRequired() // Define que o campo e obrigatorio
                .HasMaxLength(150) // Definir o maximo de caracteres
                .IsUnicode(false); // Desabilita o Unicode, o Unicode vem por padrao habilitado, se deixar ele habilitado o VARCHAR vira NVARCHAR, que aceita todos os alfabetos existentes, que por consequencia gasta muito mais espaco

                // Configurando o campo, para definir oq ele e e quantos e quais tipos de caracteres ele ira aceitar
                entity.Property(u => u.Email)
                .IsRequired() // Define que o campo e obrigatorio
                .HasMaxLength(150) // Definir o maximo de caracteres
                .IsUnicode (false);// Desabilita o Unicode, o Unicode vem por padrao habilitado, se deixar ele habilitado o VARCHAR vira NVARCHAR, que aceita todos os alfabetos existentes, que por consequencia gasta muito mais espaco

                // Deixar o Email unico
                entity.HasIndex(u => u.Email)
                .IsUnique();

                // Configurando o campo, para definir oq ele e e quantos e quais tipos de caracteres ele ira aceitar
                entity.Property(u => u.Senha)
                .IsRequired() // Define que o campo e obrigatorio
                .HasMaxLength(255) // Definir o maximo de caracteres
                .IsUnicode (false);// Desabilita o Unicode, o Unicode vem por padrao habilitado, se deixar ele habilitado o VARCHAR vira NVARCHAR, que aceita todos os alfabetos existentes, que por consequencia gasta muito mais espaco

                // Configurando o campo, para definir oq ele e e quantos e quais tipos de caracteres ele ira aceitar
                entity.Property(u => u.Telefone)
                .HasMaxLength(15) // Definir o maximo de caracteres
                .IsUnicode(false); // Desabilita o Unicode, o Unicode vem por padrao habilitado, se deixar ele habilitado o VARCHAR vira NVARCHAR, que aceita todos os alfabetos existentes, que por consequencia gasta muito mais espaco

                // Configurando o campo, para definir oq ele e e quantos e quais tipos de caracteres ele ira aceitar
                entity.Property(u => u.DataCadastro)
                .IsRequired(); // Define que o campo e obrigatorio

                // Configurando o campo, para definir oq ele e e quantos e quais tipos de caracteres ele ira aceitar
                entity.Property(u => u.DataAtualizacao)
                .IsRequired(); // Define que o campo e obrigatorio

                // Configurando o Relacionamento 1 : N entre as tabelas Usuarios e TipoUsuario 
                entity.HasOne(u => u.TipoUsuario) // Cadas usuario tem 1 Tipo
                .WithMany(t => t.Usuarios) // Um Tipo tem varios usuarios
                .HasForeignKey(u => u.TipoUsuarioId) // Configurando a Chave estrangeira
                .OnDelete(DeleteBehavior.Cascade); // Permite apagar os dados da tabela TipoUsuario, e quando apagar tambem ira apagar todos os Clientes que tem esse tipo de Usuario
            });

            // Definir os dados que o banco de Dados ira recber
            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                //  Como definir a Primary Key
                entity.HasKey(u => u.TipoUsuarioId);

                // Configurando o campo, para definir oq ele e e quantos e quais tipos de caracteres ele ira aceitar
                entity.Property(t  => t.DescricaoTipo)
                .IsRequired() // Define que o campo e obrigatorio
                .HasMaxLength(255) // Definir o maximo de caracteres
                .IsUnicode (false); // Desabilita o Unicode, o Unicode vem por padrao habilitado, se deixar ele habilitado o VARCHAR vira NVARCHAR, que aceita todos os alfabetos existentes, que por consequencia gasta muito mais espaco

                // Descricao nao pode se repetir
                entity.HasIndex(t  => t.DescricaoTipo)
                .IsUnique(); // Define que o campo e obrigatorio
            });

            // Definir os dados que o banco de Dados ira recber
            modelBuilder.Entity<Livro>(entity =>
            {
                //  Como definir a Primary Key
                entity.HasKey(l => l.LivroId);

                // Configurando o campo, para definir oq ele e e quantos e quais tipos de caracteres ele ira aceitar
                entity.Property(l => l.Titulo)
                .IsRequired() // Define que o campo e obrigatorio
                .HasMaxLength(100) // Definir o maximo de caracteres
                .IsUnicode(false); // Desabilita o Unicode, o Unicode vem por padrao habilitado, se deixar ele habilitado o VARCHAR vira NVARCHAR, que aceita todos os alfabetos existentes, que por consequencia gasta muito mais espaco

                // Configurando o campo, para definir oq ele e e quantos e quais tipos de caracteres ele ira aceitar
                entity.Property(l => l.Autor)
                .IsRequired() // Define que o campo e obrigatorio
                .HasMaxLength(150) // Definir o maximo de caracteres
                .IsUnicode(false); // Desabilita o Unicode, o Unicode vem por padrao habilitado, se deixar ele habilitado o VARCHAR vira NVARCHAR, que aceita todos os alfabetos existentes, que por consequencia gasta muito mais espaco

                // Configurando o campo, para definir oq ele e e quantos e quais tipos de caracteres ele ira aceitar
                entity.Property(l => l.Descricao)
                .HasMaxLength(255) // Definir o maximo de caracteres
                .IsUnicode(false); // Desabilita o Unicode, o Unicode vem por padrao habilitado, se deixar ele habilitado o VARCHAR vira NVARCHAR, que aceita todos os alfabetos existentes, que por consequencia gasta muito mais espaco

                // Configurando o campo, para definir oq ele e e quantos e quais tipos de caracteres ele ira aceitar
                entity.Property(l => l.DataPublicacao)
                .IsRequired(); // Define que o campo e obrigatorio

                // Configurando o Relacionamento 1 : N entre a tabela Livros e a tabela Categoria
                entity.HasOne(l => l.Categoria) // Cada Livro tem uma Categoria
                .WithMany(c => c.Livros) // Uma Categoria tem varios Livros
                .HasForeignKey(l => l.CategoriaId) // Configurando a Chave estrangeira
                .OnDelete(DeleteBehavior.Cascade);// Permite apagar os dados da tabela Categoria, e quando apagar tambem ira apagar todos os Livros que tem essa Categoria
            });

            // Definir os dados que o banco de Dados ira recber
            modelBuilder.Entity<Categoria>(entity =>
            {
                //  Como definir a Primary Key
                entity.HasKey(c => c.CategoriaId);

                // Configurando o campo, para definir oq ele e e quantos e quais tipos de caracteres ele ira aceitar
                entity.Property(c => c.NomeCategoria)
                .IsRequired() // Define que o campo e obrigatorio
                .HasMaxLength(100) // Definir o maximo de caracteres
                .IsUnicode(false); // Desabilita o Unicode, o Unicode vem por padrao habilitado, se deixar ele habilitado o VARCHAR vira NVARCHAR, que aceita todos os alfabetos existentes, que por consequencia gasta muito mais espaco
            });

            // Definir os dados que o banco de Dados ira recber
            modelBuilder.Entity<Assinatura>(entity =>
            {
                    //  Como definir a Primary Key
                    entity.HasKey(a => a.AssinaturaId);

                    // Configurando o campo, para definir oq ele e e quantos e quais tipos de caracteres ele ira aceitar
                    entity.Property(a => a.DataInicio)
                    .IsRequired(); // Define que o campo e obrigatorio

                    // Configurando o campo, para definir oq ele e e quantos e quais tipos de caracteres ele ira aceitar
                    entity.Property(a => a.DataFim)
                    .IsRequired(); // Define que o campo e obrigatorio

                    // Configurando o campo, para definir oq ele e e quantos e quais tipos de caracteres ele ira aceitar
                    entity.Property(a => a.Status)
                    .IsRequired() // Define que o campo e obrigatorio
                    .HasMaxLength(100) // Definir o maximo de caracteres
                    .IsUnicode(false); // Desabilita o Unicode, o Unicode vem por padrao habilitado, se deixar ele habilitado o VARCHAR vira NVARCHAR, que aceita todos os alfabetos existentes, que por consequencia gasta muito mais espaco

                    // Configurando o relacionamento 1 : N entre as tabelas Assinaturas e Usuario
                    entity.HasOne(a => a.Usuario) // Cada Usuario tem uma Assinatura
                    .WithMany() // Cada Assinatura tem muitos Usuarios (Esta diferente pois aqui eu nao listo o usuario, entao basta deixar o parenteses vazio
                    .HasForeignKey(a => a.UsuarioId) // Configurando a Chave estrangeira
                    .OnDelete(DeleteBehavior.Cascade);// Permite apagar os dados da tabela Categoria, e quando apagar tambem ira apagar todos os Livros que tem essa Categoria
            });
        }
    }
}
