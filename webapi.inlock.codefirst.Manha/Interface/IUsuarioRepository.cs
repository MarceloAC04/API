using webapi.inlock.codefirst.Manha.Domains;

namespace webapi.inlock.codefirst.Manha.Interface
{
    public interface IUsuarioRepository
    {
        UsuarioDomain BuscarUsuario(string email, string senha);

        void Cadastrar(UsuarioDomain novoUsuario);
    }
}
