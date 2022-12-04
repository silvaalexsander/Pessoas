using Pessoas.Models;
using System.Data;
using System.Data.SqlClient;

namespace Pessoas.Repository
{
    public class PessoasRepository
    {
        public IList<Pessoa> Listar()
        {
            IList<Pessoa> lista = new List<Pessoa>();

            var connectionString = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("TableConnection");
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                String query = "SELECT IDPESSOA, NAME, ADDRESS FROM PESSOA";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Pessoa pessoa = new Pessoa();
                    pessoa.idPessoa = Convert.ToInt32(dataReader["IDPESSOA"]);
                    pessoa.name = dataReader["NAME"].ToString();
                    pessoa.address = dataReader["ADDRESS"].ToString();

                    lista.Add(pessoa);
                    
                }
                connection.Close();
            }
            return lista;
        }

        public Pessoa Consultar(int id)
        {
            Pessoa pessoa = new Pessoa();
            
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("TableConnection");
            using(SqlConnection connection =new SqlConnection(connectionString))
            {
                String query = "SELECT IDPESSOA, NAME, ADDRESS FROM PESSOA WHERE IDPESSOA = @IDPESSOA";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@IDPESSOA", SqlDbType.Int);
                command.Parameters["@IDPESSOA"].Value = id;
                connection.Open();

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    pessoa.idPessoa = Convert.ToInt32(dataReader["IDPESSOA"]);
                    pessoa.name = dataReader["NAME"].ToString();
                    pessoa.address = dataReader["ADDRESS"].ToString();
                }

                connection.Close();
            }
            return pessoa;
        }


        public void Inserir(Pessoa pessoa)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("TableConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "INSERT INTO PESSOA ( NAME, ADDRESS ) VALUES ( @name, @address ) ";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add("@name", SqlDbType.Text);
                command.Parameters["@name"].Value = pessoa.name;
                command.Parameters.Add("@address", SqlDbType.Text);
                command.Parameters["@address"].Value = pessoa.address;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void Alterar(Pessoa pessoa)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("TableConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "UPDATE PESSOA SET NAME = @name , ADDRESS = @address WHERE IDPESSOA = @id  ";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add("@name", SqlDbType.Text);
                command.Parameters.Add("@address", SqlDbType.Text);
                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@name"].Value = pessoa.name;
                command.Parameters["@address"].Value = pessoa.address;
                command.Parameters["@id"].Value = pessoa.idPessoa;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void Excluir(int id)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("TableConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "DELETE PESSOA WHERE IDPESSOA = @id  ";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@id"].Value = id;

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

        }
    }
}
