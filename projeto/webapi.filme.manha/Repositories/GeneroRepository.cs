using System.Data.SqlClient;
using webapi.filme.manha.Domains;
using webapi.filme.manha.Interfaces;

namespace webapi.filme.manha.Repositories
{
    public class GeneroRepository : IGeneroRepository
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
                                                                                          // Integrated Security = true";
        
        /// <summary>
        /// Atualiza um objeto genero passando seu id e o corpo de requisição
        /// </summary>
        /// <param name="genero">Objeto genero a ser atualizado</param>
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao)) 
            {
                string queryUpdateById = "UPDATE Genero Set Nome = @Nome WHERE IdGenero = @Id";

                //Declara o SqlComand passando a query que sera executada e a conexao com o banco
                using (SqlCommand cmd = new SqlCommand(queryUpdateById, con))
                {
                    //Passa o valor do parametro @Nome
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);

                    cmd.Parameters.AddWithValue("@Id", genero.IdGenero);

                    //Abre a conexao com o banco de dados
                    con.Open();

                    //Executa a query (queryINSERT)
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Atualiza um objeto genero atraves da url passando seu id
        /// </summary>
        /// <param name="id">Id do objeto a ser atualizado</param>
        /// <param name="genero">objeto genero a ser atualizado </param>
        public void AtualizarIdUlr(int id, GeneroDomain genero)
        {
           using (SqlConnection con = new SqlConnection(StringConexao)) 
           {
                string queryUpdateByIdUlr = "UPDATE Genero Set Nome = @Nome WHERE IdGenero = @Id";

                //Declara o SqlComand passando a query que sera executada e a conexao com o banco
                using (SqlCommand cmd = new SqlCommand(queryUpdateByIdUlr, con))
                {
                    //Passa o valor do parametro @Nome
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);

                    cmd.Parameters.AddWithValue("@Id", id);

                    //Abre a conexao com o banco de dados
                    con.Open();

                    //Executa a query (queryINSERT)
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Busca um genero pelo seu id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>o obejto genero encontrado</returns>
        public GeneroDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a instrução a ser executada, filtrando pelo ID
                string querySelectById = "SELECT IdGenero, Nome FROM Genero WHERE IdGenero = @Id";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // Define o parâmetro @Id com o valor fornecido
                    cmd.Parameters.AddWithValue("@Id", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        GeneroDomain generoEncontrado = new GeneroDomain()
                        {
                            IdGenero = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString()
                        };

                        //Retorna um o objeto genero encontrado
                        return generoEncontrado;
                    }
                   return null;
      
                }
            }
        }


        /// <summary>
        /// Cadastrar um novo genero
        /// </summary>
        /// <param name="novoGenero">Objeto com as informações que serão cadasytradas</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            //Declara a conexao passando a StringConexao como parametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que sera executada
                string queryInsert = "INSERT INTO Genero(Nome) VALUES (@Nome)";

                //Declara o SqlComand passando a query que sera executada e a conexao com o banco
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //Passa o valor do parametro @Nome
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);

                    //Abre a conexao com o banco de dados
                    con.Open();

                    //Executa a query (queryINSERT)
                    cmd.ExecuteNonQuery();
                }

            }
        }
        /// <summary>
        /// Delata um genero cadastrado
        /// </summary>
        /// <param name="id">id do genero a ser deletado</param>
        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
              string queryDelete =  $"DELETE FROM Genero WHERE idGenero = {id}";

              using (SqlCommand cmd = new SqlCommand(queryDelete, con))
              {

                    con.Open();

                    cmd.ExecuteNonQuery();
              }
            }

        }

        /// <summary>
        /// Listar todos os obejtos generos
        /// </summary>
        /// <returns>Lista de objetos (generos)</returns>
        public List<GeneroDomain> ListarTodos()
        {
            //Cria uma lista de objetos tipo genero
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();

            //Declara a SqlConnection passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                 //Declara a instrução a ser executada
                 string querySelectAll  = "SELECT IdGenero, Nome FROM Genero";

                 //Abre a conexao com o banco de dados
                 con.Open();

                ////Declara o SqlDataReader para percorrer a tabela do banco
                SqlDataReader rdr;

                //Declara o SqlComand passando a query que sera executada e a conexao com o banco
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //Atribui a propriedade IdGenero o valor recebido no rdr
                            IdGenero = Convert.ToInt32(rdr[0]),

                            //Atribui a propriedade Nome o valor recebido no rdr
                            Nome = rdr["Nome"].ToString()
                        };

                        //Adiciona cada objeto dentro da lista
                        listaGeneros.Add(genero);
                    }
                }
            }
            //Retorna a lista de generos
            return listaGeneros;
        }
    }
}
