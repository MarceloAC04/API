using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codefirst.Manha.Domains
{
    [Table("Estudio")]
    public class EstudioDomain
    {
        [Key]
        public Guid IdEstudio { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required (ErrorMessage = "Nome do estudio é obrigatório")] 
        public string Nome { get; set; }

        public List<JogoDomain>? Jogo { get; set; }
    }
}
