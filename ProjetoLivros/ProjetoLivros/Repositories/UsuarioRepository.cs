using ProjetoLivros.Context;
using ProjetoLivros.Dto;
using ProjetoLivros.Inteface;
using ProjetoLivros.Models;
using ProjetoLivros.ViewModels;

namespace ProjetoLivros.Repositories
{
    /*
     * 1 - Herdar a interface
     * 2 - Implementar a Interface ctrl = .
     * 3 - Injetar o Contexto
    */
    public class UsuarioRepository : IUsuarioRepository
    {

        // Injecao do Contexto
        private readonly LivrosContext _context;
        public void Atualizar(CadastrarUsuarioDto usuario)
        {
            throw new NotImplementedException();
        }

        public ListarUsuarioViewModel BuscarPorId(int id)
        {
            // FirstorDefault - Traz o primeiro que encontrar ou null <nada> (melhor para filtrar)
            return _context.Usuarios.FirstOrDefault(u => new ListarUsuarioViewModel
            {
                UsuarioId = u.UsuarioId
            }); // Acessa a tabela, pega o primeiro que encontrar, me retorne aquele que tem o UsuarioId igual ao id dado
        }

        public void Cadastar(CadastrarUsuarioDto usuario)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<ListarUsuarioViewModel> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
