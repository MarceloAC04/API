using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filme.manha.Domains;
using webapi.filme.manha.Interfaces;
using webapi.filme.manha.Repositories;

namespace webapi.filme.manha.Controllers
{
    //Define que a rota de uma requisição será no seguinte formato
    //domino/api/Nomecontroller
    //ex: http://localhost:5000/api/genero
    [Route("api/[controller]")]

    //Define que é  um controlador de API
    [ApiController]

    //Define que o tipo de resposta da API sera formato JSON
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Endpoint que aciona o metodo login no repositorio
        /// </summary>
        /// <param name="email">email do usuario</param>
        /// <param name="senha">senha do usuario</param>
        /// <returns>retorna a resposta para o usuario(front-end)</returns>
        [HttpGet]
        public IActionResult Get(string email, string senha)
        {
            try
            {
                //Cria um objeto que recebe os dados da requisicao
                UsuarioDomain usuarioEncontrado = _usuarioRepository.Login(email, senha);

                if (usuarioEncontrado == null)
                {
                    return NotFound("Nenhum usuário foi encontrado");
                }

                //Retorna o objeto no formato JSON com o status code Ok(200)
                return Ok(usuarioEncontrado);

            }
            catch (Exception erro)
            {
                //Retorna um status code BadRequest(400) e a mensagem erro
                return BadRequest(erro.Message);
            }
        }

    }
}
