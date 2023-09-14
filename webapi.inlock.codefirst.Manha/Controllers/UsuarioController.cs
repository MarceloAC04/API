using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.inlock.codefirst.Manha.Domains;
using webapi.inlock.codefirst.Manha.Interface;
using webapi.inlock.codefirst.Manha.Repositories;

namespace webapi.inlock.codefirst.Manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController() 
        { 
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(UsuarioDomain novoUsuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(novoUsuario);

                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
