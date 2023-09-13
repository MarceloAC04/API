using Microsoft.EntityFrameworkCore;
using webApi.Inlock.dbFirst.Manha.Contexts;
using webApi.Inlock.dbFirst.Manha.Domains;
using webApi.Inlock.dbFirst.Manha.Interface;

namespace webApi.Inlock.dbFirst.Manha.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        InLockContext ctx = new InLockContext();

        public void Atualizar(Guid id, Estudio estudio)
        {
           Estudio estudioBuscado = ctx.Estudios.Find(id)!;
           
            if (estudioBuscado != null) 
            { 
                estudioBuscado.Nome = estudio.Nome;
            }

            ctx.Estudios.Update(estudioBuscado);

            ctx.SaveChanges();

        }

        public Estudio BuscarPorId(Guid id)
        {
            return ctx.Estudios.FirstOrDefault(e => e.IdEstudio == id)!;
        }

        public void Cadastrar(Estudio estudio)
        {

            ctx.Estudios.Add(estudio);

            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Estudio Buscado = ctx.Estudios.Find(id);

           ctx.Estudios.Remove(Buscado);

           ctx.SaveChanges();
        }

        public List<Estudio> Listar()
        {
            return ctx.Estudios.ToList();
        }

        public List<Estudio> ListarComJogos()
        {
            return ctx.Estudios.Include(e => e.Jogos).ToList();
        }
    }
}
