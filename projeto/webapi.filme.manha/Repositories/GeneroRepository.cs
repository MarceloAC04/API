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
                                                                                         
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUlr(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
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
                string queryInsert = "INSERT INTO Genero(Nome) VALUES ('"+ novoGenero.Nome +"')";

                //Declara o SqlComand passando a query que sera executada e a conexao com o banco
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //Abre a conexao com o banco de dados
                    con.Open();

                    //Executa a query (queryINSERT)
                    cmd.ExecuteNonQuery();
                }

            }
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
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

                //Declara o SqlDataReader para percorrer a tabela do banco
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
