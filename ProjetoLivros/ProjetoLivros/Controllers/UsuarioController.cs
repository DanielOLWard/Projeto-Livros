using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoLivros.Dto;
using ProjetoLivros.Inteface;
using ProjetoLivros.Services;

namespace ProjetoLivros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        // Instanciar o PasswordService
        private PasswordService _passwordService;
        // Injecao de dependencia
        // Ao invez  de EU instanciar a classe, Eu aviso que DEPENDO dela, e a responsabilidade de criar vai para a classe que for chamada
        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // Listar Usuarios
        [HttpGet]
        public async Task <IActionResult> ListarUsuarios() // Se utilizar o async tem que usar o async e o task e emcapsular o IActionResult
        {
            var usuario = await _usuarioRepository.ListarTodosAsync(); // Criar uma variavel para guaradar o usuario e usar o await
            return Ok(usuario);
        }

        // cadastrar Usuario
        [HttpPost]
        public IActionResult CadastrarUsuario(CadastrarUsuarioDto usuarioDto)
        {
            _usuarioRepository.Cadastrar(usuarioDto);

            return Created();
        }

    }
}
