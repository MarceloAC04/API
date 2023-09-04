using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.InteropServices;
using System.Security.Claims;
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
        [HttpPost]
        public IActionResult Post(string email, string senha)
        {
            try
            {
                //Cria um objeto que recebe os dados da requisicao
                UsuarioDomain usuarioEncontrado = _usuarioRepository.Login(email, senha);

                if (usuarioEncontrado == null)
                {
                    return NotFound("Usuário ou Senha Inválidos");
                }

                //Caso encontre o usuário, prossegue para criação do token

                //1) - Defini as informações(claims) que serão fornecidas no token(PAYLOAD)
                var claims = new[]
                {
                    new Claim(JwtRegistredClaimNames.Jti, usuarioEncontrado.IdUsuario.ToString()), 
                    new Claim(JwtRegistredClaimNames.Email, usuarioEncontrado.Email),
                    new Claim(ClaimTypes.Role, usuarioEncontrado.Permissao.ToString()),


                    //Existe a possibilidade de criar uma claim personalizada
                    new Claim("Claim personalizada", "Valor da Claim personalizada")
                };

                //2) - Defini a chave de acesso ao Token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev"));


                //3) - Defini as credenciais do token (HEADER)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //4) - Gerar o token 
                var token = new JwtSecurityToken
                (
                    //emissor do token
                    issuer: "webapi.filme.manha",

                    //Destinatario de token
                    audience: "webapi.filme.manha",

                    //dados definidos nas claims(Informações)
                    claims: claims,

                    //tempo de expiração de token
                    expires: DateTime.Now.AddMinutes(5),

                    //credencias do token
                    signingCredentials: creds
                );

                //5) - Retorna o token criado
                return Ok( new {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }
            catch (Exception erro)
            {
                //Retorna um status code BadRequest(400) e a mensagem erro
                return BadRequest(erro.Message);
            }
        }

    }
}
