using Microsoft.EntityFrameworkCore;
using ProjetoLivros.Context;
using ProjetoLivros.Dto;
using ProjetoLivros.Inteface;
using ProjetoLivros.Models;
using ProjetoLivros.Services;
using ProjetoLivros.ViewModels;

namespace ProjetoLivros.Repositories
{
    /*
     * 1 - Herdar a interface
     * 2 - Implementar a Interface = ctrl + .
     * 3 - Injetar o Contexto
    */
    public class UsuarioRepository : IUsuarioRepository
    {

        // Injecao do Contexto
        private readonly LivrosContext _context;

        //Injecao do Contexto
        // ctor crio a linha abaixo
        public UsuarioRepository(LivrosContext context)
        {
            _context = context;
        }

        public Usuario? Atualizar(int id, AtualizarUsuarioDto usuarioNovo)
        {
            // 1 - Encontro o usuario que desejo atualizar
            var usuarioEncontrado = _context.Usuarios.Find(id);

            // Crio a variavel para usar o sistema de hash
            var passwordService = new PasswordService();

            // Tratamento de erro
            if (usuarioEncontrado == null) return null;

            // Atualizo os Campos um por 1
            usuarioEncontrado.NomeCompleto = usuarioNovo.NomeCompleto;
            usuarioEncontrado.Email = usuarioNovo.Email;
            usuarioEncontrado.Senha = usuarioNovo.Senha;
            usuarioEncontrado.DataAtualizacao = usuarioNovo.DataAtualizacao;
            usuarioEncontrado.Telefone = usuarioNovo.Telefone;
            usuarioEncontrado.TipoUsuarioId = usuarioNovo.TipoUsuarioId;

            // Tranformar a senha Atualizada em hash
            usuarioEncontrado.Senha = passwordService.HashPassword(usuarioEncontrado);

            _context.SaveChanges();

            return usuarioEncontrado;
        }

        public ListarUsuarioViewModel BuscarPorId(int id)
        {
            // FirstorDefault - Traz o primeiro que encontrar ou null <nada> (melhor para filtrar)
            return _context.Usuarios
                .Select(u => new ListarUsuarioViewModel
                {
                    UsuarioId = u.UsuarioId,
                    NomeCompleto = u.NomeCompleto,
                    Email = u.Email,
                    Telefone = u.Telefone,
                    DataCadastro = u.DataCadastro,
                    TipoUsuarioId = u.TipoUsuarioId
                })
                .FirstOrDefault(u => u.UsuarioId == id); // Acessa a tabela, pega o primeiro que encontrar, me retorne aquele que tem o UsuarioId igual ao id dado
        }

        public void Cadastrar(CadastrarUsuarioDto usuarioDto)
        {
            // Crio a variavel para usar o sistema de hash
            var passwordService = new PasswordService();

            // Crio a variavel usuario para guardar as informacoes do Usuario
            var usuarioCadastrado = new Usuario
            {
                NomeCompleto = usuarioDto.NomeCompleto,
                Email = usuarioDto.Email,
                Senha = usuarioDto.Senha,
                Telefone = usuarioDto.Telefone,
                DataCadastro = usuarioDto.DataCadastro,
                TipoUsuarioId = usuarioDto.TipoUsuarioId
            };

            // Tranformo a senha informada em hash
            usuarioCadastrado.Senha = passwordService.HashPassword(usuarioCadastrado);

            _context.Usuarios.Add(usuarioCadastrado); // Salva o Usuario no Banco de Dados

            _context.SaveChanges(); // Sempre colocar o SaveChanges quando alterar algo no Banco de Dados
        }

        public Usuario? Deletar(int id)
        {
            // 1 - encontro o Usuario que eu quero excluir
            Usuario usuarioEncontrado = _context.Usuarios.Find(id); // Find - Procura apenas pela chave primaria

            // tratamento de erro
            if (usuarioEncontrado == null)
            {
                return null;
            }

            // 2 - Se eu encontrar o Usuario, Excluo ele
            _context.Usuarios.Remove(usuarioEncontrado);

            // 3 - Salvo as alteracoes
            _context.SaveChanges();

            return usuarioEncontrado;
        }

        public async Task<List<ListarUsuarioViewModel>> ListarTodosAsync()
        {
            return await _context.Usuarios
               .Select(u => new ListarUsuarioViewModel // Select - Seleciona os Dados que eu quero ou que eu preciso
               {
                   UsuarioId = u.UsuarioId,
                   NomeCompleto = u.NomeCompleto,
                   Email = u.Email,
                   Telefone = u.Telefone,
                   DataCadastro = u.DataCadastro,
                   TipoUsuarioId = u.UsuarioId
               })
               .ToListAsync(); // ToListAsync - Listar varios
        }
    }
}
