using webapi.filme.manha.Domains;

namespace webapi.filme.manha.Interfaces
{
    /// <summary>
    /// Interface responsavel pelo repositorio UsuarioRepository
    /// Definir os metodos que serao implementados pelo UsuarioRepository
    /// </summary>
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Faz o login de acesso do usuario 
        /// </summary>
        /// <param name="email">Usuario cadastrado que sera logadp</param>
        UsuarioDomain Login(string email, string senha);
    }
}
