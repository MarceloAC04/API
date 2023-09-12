using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            catch (Exception)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
