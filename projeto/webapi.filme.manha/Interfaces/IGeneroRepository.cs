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

        /// <summary>
        /// Cadastrar um novo genero
        /// </summary>
        /// <param name="novoGenero">Objeto que sera cadastrado</param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista com os objetos</returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Atualiza um objeto existente passando seu id e o corpo da requisição
        /// </summary>
        /// <param name="genero">Objeto atualizado</param>
        void AtualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// Atualiza o objeto existente passando seu id pela URL
        /// </summary>
        /// <param name="id">Id do objeto que sera atualizado</param>
        /// <param name="genero">Genero do objeto atualizado com as novas informações</param>
        void AtualizarIdUlr(int id , GeneroDomain genero );

        /// <summary>
        /// Deleta um objeto
        /// </summary>
        /// <param name="id">Id do objeto que sera deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Busca um objeto atraves de seu id
        /// </summary>
        /// <param name="id">Id do objeto a ser buscado</param>
        /// <returns></returns>
        GeneroDomain BuscarPorId(int id);

    }
}
