using webapi.filme.manha.Domains;

namespace webapi.filme.manha.Interfaces
{
    public interface IFilmeRepository
    {
        /// <summary>
        /// Cadastrar um novo filme
        /// </summary>
        /// <param name="novoFilme">Objeto que sera cadastrado</param>
        void Cadastrar(FilmeDomain novoFilme);

        /// <summary>
        /// Listar todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista com os objetos</returns>
        List<FilmeDomain> ListarTodos();

        /// <summary>
        /// Atualiza um objeto existente passando seu id e o corpo da requisição
        /// </summary>
        /// <param name="filme">Obejto atualizado</param>
        void AtualizarIdCorpo(FilmeDomain filme);

        /// <summary>
        /// Atualiza o objeto existente passando seu id pela URL
        /// </summary>
        /// <param name="id">Id do objeto que sera atualizado</param>
        /// <param name="filme">filme a ser atualizado com as novas informações</param>
        void AtualizarIdUlr(int id, FilmeDomain filme);

        /// <summary>
        /// Deleta um objeto
        /// </summary>
        /// <param name="id">Id do objeto que sera deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Busca um objeto atraves de seu id
        /// </summary>
        /// <param name="id">Id do obejto a ser buscado</param>
        /// <returns></returns>
        FilmeDomain BuscarPorId(int id);

    }
}
