using webapi.filme.manha.Domains;

namespace webapi.filme.manha.Interfaces
{
    /// <summary>
    /// Interface responsavel pelo repositorio GeneroRepository
    /// Definir os metodos que serao implementados pelo GeneroRepository
    /// </summary>
    public interface IGeneroRepository
    {
        //TipoRetorno NomeMetodo(TipoParametro NomeParametro)

        void Cadastrar(GeneroDomain novoGenero);
        List<GeneroDomain> ListarTodos();

        void AtualizarIdCorpo(GeneroDomain genero);

        void Deletar(int id);
    }
}
