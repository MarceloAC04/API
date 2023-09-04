using System.ComponentModel.DataAnnotations;

namespace webapi.filme.manha.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O email do usuário é obrigatório!")]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 4, ErrorMessage ="A senha dever ter de 4 a 20 caracteres")]
        [Required(ErrorMessage = "A senha do usuário é obrigatório!")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O nome do usuário é obrigatório!")]
        public string Nome { get; set; }
        public bool Permissao { get; set; }
    }
}
