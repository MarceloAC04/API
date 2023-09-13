using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codefirst.Manha.Domains
{
    [Table("Usuario")]
    public class UsuarioDomain
    {
        [Key]
        public Guid IdUsuario { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O Email do usuario é obrigatório")]

        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Senha obrigatória")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Senha deve conter de 6 a 20 caracteres")]
        public string? Senha { get; set; }

        //Referencia da chave estrangeira (Tabela TipoUsuario)
        [Required(ErrorMessage = "Tipo de Usuario obrigatorio")]
        public Guid IdTipoUsuario {get; set;}

        [ForeignKey("IdTipoUsuario")]
        public TipoUsuarioDomain TipoUsuario { get; set; }
    }
}
