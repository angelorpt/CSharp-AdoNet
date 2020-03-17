using System;
using System.Data.SqlClient;
using static System.Console;

namespace CSharpAdoNET
{
    class Program
    {
        static void Main(string[] args)
        {
            SalvarCliente("Thaís Sousa Souza", "ThaisSousaSouza@rhyta.com", 2);
            ListarClientes();
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

        static string getStringConnection()
        {
            string connString = "Server=LAPTOP-B2ADTHUP\\SQLEXPRESS;Database=CSharpAdoNet;User Id=sa;Password=root";
            return connString;
        }
    }
}
