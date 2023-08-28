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
    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// Objeto _generoRepository que ira receber todos os metodos definidos na interface IGeneroRepository
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _generoRepository para que haja referencia aos metodos no repositorio
        /// </summary>
        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// Endpoint que aciona o  metodo ListarTodos no repositorio
        /// </summary>
        /// <returns>retorna a resposta para o usuario(front-end)</returns>
        [HttpGet]
        public IActionResult Get() 
        {
            try
            {
               //Cria uma lista que recebe os dados da requisicao
               List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

               //Retorna a lista no formato JSON com o status code Ok(200)
               return Ok(listaGeneros);

            }
            catch (Exception erro) 
            {
                //Retorna um status code BadRequest(400) e a mensagem erro
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo de cadastro de genero
        /// </summary>
        /// <param name="novoGenero">Objeto recebido na requisição</param>
        /// <returns>status code 201(created)</returns>
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            try
            {

            //Fazendo a chamada para o metodo cadastrar passando o objeto novoGenero como parametro
            _generoRepository.Cadastrar(novoGenero);

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
        /// Endpoint que aciona o metodo de deletar de genero
        /// </summary>
        /// <param name="id">id do objeto recebido</param>
        /// <returns>code 201(deleted)</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            try
            {
                _generoRepository.Deletar(id);

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
               GeneroDomain generoEncontrado = _generoRepository.BuscarPorId(id);

                if (generoEncontrado == null)
                {
                    return NotFound("Nenhum genero foi encontrado");
                }

                //Retorna o objeto no formato JSON com o status code Ok(200)
                return Ok(generoEncontrado);

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
        /// <param name="genero">Id do objeto e o corpo da requisição</param>
        /// <returns>retorna StatusCode201(updated)</returns>
        [HttpPut]

        public IActionResult Put(GeneroDomain genero)
        {
            try
            {
                _generoRepository.AtualizarIdCorpo(genero);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo AtualizarIdUrl do repositorio
        /// </summary>
        /// <param name="id">Id do objeto a ser atualizado</param>
        /// <param name="genero">Genero do obejto a ser atualizado</param>
        /// <returns>retorna StatusCode201(updated)</returns>
        [HttpPut("{id}")]

        public IActionResult Put(int id, GeneroDomain genero)
        {
            try
            {
                _generoRepository.AtualizarIdUlr(id, genero);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
