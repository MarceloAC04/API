using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codefirst.Manha.Domains
{
    /// <summary>
    /// Classe que representa a entidade jogo
    /// </summary>
    [Table("Jogo")]
    public class JogoDomain
    {
        [Key]
        public Guid IdJogo { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O Nome do jogo é obrigatório")]
        public string? Nome { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A Descrição do jogo é obrigatória")]
        public string? Descricao { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data de lançamento obrigatória")]
        public DateTime DataLancamento { get; set; }

        [Column(TypeName = "Decimal(4,2)")]
        [Required(ErrorMessage = "O Preço do jogo é obrigatório")]
        public decimal Preco { get; set; }

        //Referencia da Chave estrangeira (Tabela de Estudio)
        [Required(ErrorMessage = "Informe o estúdio que produziu o jogo")]
        public Guid IdEstudio { get; set; }

        [ForeignKey("IdEstudio")]
        public EstudioDomain Estudio { get; set; }
    }
}
