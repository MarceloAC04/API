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
                                                                                            // Integrated Security = true";
        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUlr(int id, FilmeDomain filme)
        {
            throw new NotImplementedException();
        }

        public FilmeDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(FilmeDomain novoFilme)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<FilmeDomain> ListarTodos()
        {
            //Cria uma lista de objetos tipo genero
            List<FilmeDomain> listaFilmes = new List<FilmeDomain>();

            //Declara a SqlConnection passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a instrução a ser executada
                string querySelectAll = "SELECT IdFilme, Titulo, IdGenero FROM Filme";

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

                            IdGenero = Convert.ToInt32(rdr[0])
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
