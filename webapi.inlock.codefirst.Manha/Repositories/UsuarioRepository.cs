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
            try
            {
               UsuarioDomain usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.Email = email);

                if (usuarioBuscado != null)
                {
                  bool confere =  Criptografia.CompararHash(senha, usuarioBuscado.Senha);

                    if (confere)
                    {
                        return usuarioBuscado;
                    }

                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(UsuarioDomain novoUsuario)
        {
            try
            {

                novoUsuario.Senha = Criptografia.GerarHash(novoUsuario.Senha!);

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
