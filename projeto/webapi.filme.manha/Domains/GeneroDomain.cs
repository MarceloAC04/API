using System.ComponentModel.DataAnnotations;

namespace webapi.filme.manha.Domains
{
    /// <summary>
    /// Classe que representa a entidade Genero
    /// </summary>
    public class GeneroDomain
    {
        public int IdGenero { get; set; }
        [Required(ErrorMessage = "O nome do genero é obrigatório!")]
        public string? Nome { get; set; }
    }
}
