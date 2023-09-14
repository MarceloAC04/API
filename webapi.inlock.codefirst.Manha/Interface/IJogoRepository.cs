using webapi.inlock.codefirst.Manha.Domains;

namespace webapi.inlock.codefirst.Manha.Interface
{
    public interface IJogoRepository
    {
        List<JogoDomain> Listar();

        JogoDomain BuscarPorId(Guid id);

        void Cadastrar(JogoDomain novoJogo); 

        void Atualizar(Guid id, JogoDomain jogo);

        void Deletar(Guid id);
    }
}
