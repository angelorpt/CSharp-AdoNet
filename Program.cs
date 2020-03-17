using System;
using System.Data.SqlClient;
using static System.Console;

namespace CSharpAdoNET
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = "Server=LAPTOP-B2ADTHUP\\SQLEXPRESS;Database=CSharpAdoNet;User Id=sa;Password=root";
            SqlConnection conn = new SqlConnection(connString);

            conn.Open();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT ID, NOME, EMAIL FROM CLIENTES ORDER BY ID";

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                WriteLine("ID: {0}", dr["id"].ToString());
                WriteLine("Nome: {0}", dr["nome"].ToString());
                WriteLine("E-mail: {0}", dr["email"].ToString());
                WriteLine("-------------------------------------------------\n");
            }

            conn.Close();

            ReadLine();

        }
    }
}
