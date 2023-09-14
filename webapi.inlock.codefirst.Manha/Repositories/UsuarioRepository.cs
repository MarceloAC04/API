using Microsoft.AspNetCore.Http.HttpResults;
using webapi.inlock.codefirst.Manha.Contexts;
using webapi.inlock.codefirst.Manha.Domains;
using webapi.inlock.codefirst.Manha.Interface;
using webapi.inlock.codefirst.Manha.Utils;

namespace webapi.inlock.codefirst.Manha.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        /// <summary>
        /// Variavel privada e somente leitura para armazenar os dados do contexto
        /// </summary>
        private readonly InlockContext ctx;

        /// <summary>
        /// Construtor do repositorio
        /// Toda vez que o repositorio for iniciado,
        /// Ele tera acesso aos dados fornecidos pelo contexto
        /// </summary>
        public UsuarioRepository()
        {
            ctx = new InlockContext();
        }

        public UsuarioDomain BuscarUsuario(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(UsuarioDomain novoUsuario)
        {
            try
            {

                novoUsuario.Senha = Criptografia.GerarHash(novoUsuario.Senha);

                ctx.Usuario.Add(novoUsuario);

                ctx.SaveChanges();

            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
