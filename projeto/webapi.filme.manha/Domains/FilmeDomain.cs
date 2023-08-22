using System.ComponentModel.DataAnnotations;

namespace webapi.filme.manha.Domains
{
    /// <summary>
    /// Classe que representa a entidade filme
    /// </summary>
    public class FilmeDomain
    {
        public int IdFilme { get; set; }

        [Required(ErrorMessage = "O Título do filme é obrigatório!")]
        public string? Titulo { get; set; }

        public int IdGenero { get; set; }

        //Referencia para a classe genero
        public GeneroDomain Genero { get; set; }
    }
}
