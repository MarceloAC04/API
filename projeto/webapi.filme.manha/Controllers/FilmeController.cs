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

    //Metodo controlador que herda da controller base
    //Onde sera criado os Endpoints (rotas)
    public class FilmeController : ControllerBase
    {
        private IFilmeRepository _filmeRepository { get; set; }

        public FilmeController()
        {
            _filmeRepository = new FilmeRepository();
        }

        /// <summary>
        /// Endpoint que aciona o metodo Listar Todos no repositorio
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Cria uma lista que recebe os dados da requisicao
                List<FilmeDomain> listaFilmes = _filmeRepository.ListarTodos();

                //Retorna a lista no formato JSON com o status code Ok(200)
                return Ok(listaFilmes);

            }
            catch (Exception erro)
            {
                //Retorna um status code BadRequest(400) e a mensagem erro
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo cadastrar no repositorio
        /// </summary>
        /// <param name="novoFilme">Objeto filme a ser cadastrado</param>
        /// <returns>Status code 201</returns>
        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            try
            {

                //Fazendo a chamada para o metodo cadastrar passando o objeto novoGenero como parametro
                _filmeRepository.Cadastrar(novoFilme);

                //Retorna o Status Code 201
                return StatusCode(201);

            }
            catch (Exception erro)
            {
                //Retorna o Staus Code 400(BadRequest) e a mensagem do erro
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo delatar do repositorio
        /// </summary>
        /// <param name="id">Id do objeto filme a ser deletado</param>
        /// <returns>Status code 201(deleted)</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _filmeRepository.Deletar(id);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o  metodo BuscarPorId no repositorio
        /// </summary>
        /// <returns>retorna a resposta para o usuario(front-end)</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                //Cria um objeto que recebe os dados da requisicao
                FilmeDomain filmeEncontrado = _filmeRepository.BuscarPorId(id);

                if (filmeEncontrado == null)
                {
                    return NotFound("Nenhum filme foi encontrado");
                }

                //Retorna o objeto no formato JSON com o status code Ok(200)
                return Ok(filmeEncontrado);

            }
            catch (Exception erro)
            {
                //Retorna um status code BadRequest(400) e a mensagem erro
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo AtualizarIdCorpo no repositorio
        /// </summary>
        /// <param name="filme">Filme a ser atualizado</param>
        /// <returns>retorna StatusCode201(updated)</returns>
        [HttpPatch]
        public IActionResult Patch(FilmeDomain filme) 
        {
            try
            {
                FilmeDomain filmeEncontrado = _filmeRepository.BuscarPorId(filme.IdFilme);

                if (filmeEncontrado != null)
                {
                    try
                    {
                        _filmeRepository.AtualizarIdCorpo(filme);

                        return StatusCode(201);
                    }
                    catch (Exception erro)
                    { 
                        return BadRequest(erro.Message);
                    }

                }
                return BadRequest("Filme não encontrado");
            }
            catch (Exception erro) 
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPatch("{id}")]

        public IActionResult Patch(int id, FilmeDomain filme)
        {
            try
            {
                FilmeDomain filmeEncontrado = _filmeRepository.BuscarPorId(id);

                if (filmeEncontrado != null)
                {
                    try
                    {
                        _filmeRepository.AtualizarIdUlr(id, filme);

                        return StatusCode(201);
                    }
                    catch (Exception erro)
                    {
                        return BadRequest(erro.Message);
                    }

                }
                return BadRequest("Filme não encontrado");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

    }
}
