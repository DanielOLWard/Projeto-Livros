using ProjetoLivros.Dto;
using ProjetoLivros.Models;
using ProjetoLivros.ViewModels;

namespace ProjetoLivros.Inteface
{
    public interface IUsuarioRepository
    {
        Task<List<ListarUsuarioViewModel>> ListarTodosAsync();

        ListarUsuarioViewModel BuscarPorId(int id);

        void Cadastrar (CadastrarUsuarioDto usuarioDto);

        Usuario? Atualizar(int id, AtualizarUsuarioDto usuarioNovo);

        Usuario? Deletar (int id);
    }
}
