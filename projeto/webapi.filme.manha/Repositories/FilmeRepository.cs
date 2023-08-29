using System.Data.SqlClient;
using webapi.filme.manha.Domains;
using webapi.filme.manha.Interfaces;

namespace webapi.filme.manha.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        /// <summary>
        /// String de conexao com o banco de dados que recebe os seguintes parametros
        /// Data Source : Nome do servidor
        /// Initial Catalog : Nome do Banco de dados
        /// Autenticacao:
        ///     -Windows : Intergrated Security = true
        ///     -SQLServer : User Id = sa Pwd = Senha
        /// </summary>
        private string StringConexao = "Data Source = NOTE23-S15; Initial Catalog = Filmes; User Id = sa; Pwd = Senai@134";

        public object Genero { get; private set; }

        // Integrated Security = true";


        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdateById = "UPDATE Filme Set Titulo = @Titulo, IdGenero = @IdGenero  WHERE IdFilme = @Id";

                //Declara o SqlComand passando a query que sera executada e a conexao com o banco
                using (SqlCommand cmd = new SqlCommand(queryUpdateById, con))
                {
                    //Passa o valor do parametro @Nome
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);

                    cmd.Parameters.AddWithValue("@IdGenero", filme.IdGenero);

                    cmd.Parameters.AddWithValue("@Id", filme.IdFilme);

                    //Abre a conexao com o banco de dados
                    con.Open();

                    //Executa a query (queryINSERT)
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUlr(int id, FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdateById = "UPDATE Filme Set Titulo = @Titulo, IdGenero = @IdGenero  WHERE IdFilme = @Id";

                //Declara o SqlComand passando a query que sera executada e a conexao com o banco
                using (SqlCommand cmd = new SqlCommand(queryUpdateById, con))
                {
                    //Passa o valor do parametro @Nome
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);

                    cmd.Parameters.AddWithValue("@IdGenero", filme.IdGenero);

                    cmd.Parameters.AddWithValue("@Id", id);

                    //Abre a conexao com o banco de dados
                    con.Open();

                    //Executa a query (queryINSERT)
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Busca um objeto filme pelo seu id
        /// </summary>
        /// <param name="id">Id do objeto a ser encontrado</param>
        /// <returns>Objeto filme encontrado</returns>
        public FilmeDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a instrução a ser executada, filtrando pelo ID
                string querySelectById = "SELECT IdFilme, Titulo, IdGenero FROM Filme WHERE IdFilme = @Id";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // Define o parâmetro @Id com o valor fornecido
                    cmd.Parameters.AddWithValue("@Id", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FilmeDomain filmeEncontrado = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(rdr[0]),

                            IdGenero = Convert.ToInt32(rdr[0]),

                            Titulo = rdr["Titulo"].ToString()
                        };

                        //Retorna um o objeto genero encontrado
                        return filmeEncontrado;
                    }
                    return null;

                }
            }
        }

        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="novoFilme">Novo objeto filme a ser cadastrado</param>
        public void Cadastrar(FilmeDomain novoFilme)
        {
            //Declara a conexao passando a StringConexao como parametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que sera executada
                string queryInsert = "INSERT INTO Filme(Titulo, IdGenero) VALUES (@Titulo, @IdGenero)";

                //Declara o SqlComand passando a query que sera executada e a conexao com o banco
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //Passa o valor do parametro @Titulo
                    cmd.Parameters.AddWithValue("@Titulo", novoFilme.Titulo);

                    //Passa o valor do parametro @IdGenero
                    cmd.Parameters.AddWithValue("@IdGenero", novoFilme.IdGenero);

                    //Abre a conexao com o banco de dados
                    con.Open();

                    //Executa a query (queryINSERT)
                    cmd.ExecuteNonQuery();
                }

            }
        }

        /// <summary>
        /// Deleta um filme cadastrado
        /// </summary>
        /// <param name="id">id do filme a ser deletado</param>
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM Filme WHERE IdFilme = @Id";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    
                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os filmes cadastrados
        /// </summary>
        /// <returns>Lista dos filmes cadastrdos</returns>
        public List<FilmeDomain> ListarTodos()
        {
            //Cria uma lista de objetos tipo genero
            List<FilmeDomain> listaFilmes = new List<FilmeDomain>();


            //Declara a SqlConnection passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a instrução a ser executada
                string querySelectAll = "SELECT Filme.IdFilme, Filme.Titulo, Genero.Nome as Nome, Filme.IdGenero FROM Filme LEFTx JOIN Genero ON Genero.IdGenero = Filme.IdGenero";

                //Abre a conexao com o banco de dados
                con.Open();

                ////Declara o SqlDataReader para percorrer a tabela do banco
                SqlDataReader rdr;

                //Declara o SqlComand passando a query que sera executada e a conexao com o banco
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            //Atribui a propriedade IdGenero o valor recebido no rdr
                            IdFilme = Convert.ToInt32(rdr[0]),

                            //Atribui a propriedade Nome o valor recebido no rdr
                            Titulo = rdr["Titulo"].ToString(),

                            IdGenero = Convert.ToInt32(rdr[0]),


                            Genero = new GeneroDomain()
                            {

                              Nome = rdr["Nome"].ToString()

                            }
                        };

                        //Adiciona cada objeto dentro da lista
                        listaFilmes.Add(filme);
                    }
                }
            }
            //Retorna a lista de generos
            return listaFilmes;
        }
    }
}
