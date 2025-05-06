using ProjetoLivros.Dto;
using ProjetoLivros.Models;
using ProjetoLivros.ViewModels;

namespace ProjetoLivros.Inteface
{
    public interface IUsuarioRepository
    {
        List<ListarUsuarioViewModel> ListarTodos();

        ListarUsuarioViewModel BuscarPorId(int id);

        void Cadastar (CadastrarUsuarioDto usuario);

        void Atualizar (CadastrarUsuarioDto usuario);

        void Deletar (int id);
    }
}
