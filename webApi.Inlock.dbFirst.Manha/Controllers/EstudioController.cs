using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApi.Inlock.dbFirst.Manha.Domains;
using webApi.Inlock.dbFirst.Manha.Interface;
using webApi.Inlock.dbFirst.Manha.Repositories;

namespace webApi.Inlock.dbFirst.Manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_estudioRepository.Listar());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("ListarComJogos")]
        public IActionResult GetWithGamers()
        {
            try
            {
                return Ok(_estudioRepository.ListarComJogos());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetWithId(Guid id)
        {
            try
            {
                return Ok(_estudioRepository.BuscarPorId(id));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPost]
        public IActionResult Post(Estudio novoEstudio)
        {
            try
            {
                _estudioRepository.Cadastrar(novoEstudio);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {

                _estudioRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception e)
            {
               return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Estudio estudio)
        {
            try
            {
                _estudioRepository.Atualizar(id, estudio);

                return NoContent();
            }
            catch (Exception e) 
            { 
                return BadRequest(e.Message); 
            }

        }
    }
}
