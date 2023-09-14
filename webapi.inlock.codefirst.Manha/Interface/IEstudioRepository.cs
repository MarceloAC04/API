using webapi.inlock.codefirst.Manha.Domains;

namespace webapi.inlock.codefirst.Manha.Interface
{
    public interface IEstudioRepository
    {
        List<EstudioDomain> Listar();

        EstudioDomain BuscarPorId(Guid id);

        void Cadastrar(EstudioDomain estudio);

        void Atualizar(Guid id, EstudioDomain estudio);

        void Deletar(Guid id);

        List<EstudioDomain> ListarComJogos();
    }
}
