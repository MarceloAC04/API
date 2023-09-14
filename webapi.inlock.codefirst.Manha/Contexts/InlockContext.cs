using Microsoft.EntityFrameworkCore;
using webapi.inlock.codefirst.Manha.Domains;

namespace webapi.inlock.codefirst.Manha.Contexts
{
    public class InlockContext : DbContext
    {
        //Define as entidades do banco de dados
        public DbSet<EstudioDomain> Estudio { get; set; }

        public DbSet<JogoDomain> Jogo { get; set; }

        public DbSet<TipoUsuarioDomain> TipoUsuario { get; set; }

        public DbSet<UsuarioDomain> Usuario { get; set; }

        /// <summary>
        /// Define as opções de contrusção do banco(String Conexão)
        /// </summary>
        /// <param name="optionsBuilder">Objeto com as configurações definidas</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE23-S15; Database=Inlock_games_codeFirst_manha; User Id=sa; Pwd=Senai@134; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
