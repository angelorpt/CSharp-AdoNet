using System;
using System.Data.SqlClient;
using static System.Console;

namespace CSharpAdoNET
{
    class Program
    {
        static void Main(string[] args)
        {

            WriteLine("=================== CONTROLE DE CLIENTES ===================\n");
            WriteLine("Selecione uma opção:");
            WriteLine("1 - Listar");
            WriteLine("2 - Cadastrar");
            WriteLine("3 - Editar");
            WriteLine("4 - Excluir");
            WriteLine("5 - Visualizar");

            int opc = Convert.ToInt32(ReadLine());

            Clear();
            switch (opc)
            {
                case 1:
                    Title = "Listagem de Clientes";
                    WriteLine("=================== LISTAGEM DE CLIENTES ===================\n");
                    ListarClientes();
                    break;

                case 2:
                    Title = "Novo Cliente";
                    WriteLine("=================== NOVO CLIENTE ===================\n");

                    Write("Informe um nome: ");
                    string nome = ReadLine();

                    Write("Informe um email: ");
                    string email = ReadLine();

                    SalvarCliente(nome, email);

                    break;

                case 3:
                    Title = "Editar Cliente";
                    WriteLine("=================== EDITAR CLIENTE ===================\n");
                    break;

                case 4:
                    Title = "Excluir Cliente";
                    WriteLine("=================== EXCLUIR CLIENTE ===================\n");
                    break;

                case 5:
                    Title = "Visualizar Cliente";
                    WriteLine("=================== VISUALIZAR CLIENTE ===================\n");
                    break;
                default:
                    Title = "Opção Inválida";
                    WriteLine("=================== SELECIONE UMA OPÇÃO VÁLIDA ===================\n");
                    break;
            }

            ReadLine();
        }

        static void ListarClientes()
        {

            string connString = getStringConnection();

            using (SqlConnection conn = new SqlConnection(connString))
            {

                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT ID, NOME, EMAIL FROM CLIENTES ORDER BY ID";

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        WriteLine("ID: {0}", dr["id"].ToString());
                        WriteLine("Nome: {0}", dr["nome"].ToString());
                        WriteLine("E-mail: {0}", dr["email"].ToString());
                        WriteLine("-------------------------------------------------\n");
                    }
                }
            }
        }


        static void SalvarCliente(string nome, string email)
        {
            string connString = getStringConnection();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd  = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO CLIENTES (NOME, EMAIL) VALUES (@nome, @email)";
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.ExecuteNonQuery();
            }
        }

        static void SalvarCliente(string nome, string email, int id)
        {
            string connString = getStringConnection();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE CLIENTES SET NOME = @nome, EMAIL = @email WHERE ID = @id";
                cmd.Parameters.AddWithValue("@nome" , nome);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@id"   , id);
                cmd.ExecuteNonQuery();
            }
        }

        static void DeletarCliente(int id)
        {
            string connString = getStringConnection();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM CLIENTES WHERE ID = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        static (int, string, string) SelecionarCliente(int id)
        {
            string connString = getStringConnection();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT ID, NOME, EMAIL FROM CLIENTES WHERE ID = @id";
                cmd.Parameters.AddWithValue("@id", id);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    dr.Read();
                    return (Convert.ToInt32(dr["id"].ToString()), dr["nome"].ToString(), dr["email"].ToString());
                }
            }
        }

        static string getStringConnection()
        {
            string connString = "Server=LAPTOP-B2ADTHUP\\SQLEXPRESS;Database=CSharpAdoNet;User Id=sa;Password=root";
            return connString;
        }
    }
}
