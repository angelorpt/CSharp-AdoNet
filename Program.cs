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

            WriteLine(conn);
            ReadKey();

            Console.WriteLine("Hello World!");
        }
    }
}
