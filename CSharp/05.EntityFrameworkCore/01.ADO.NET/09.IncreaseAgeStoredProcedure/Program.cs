using Microsoft.Data.SqlClient;

namespace _09.IncreaseAgeStoredProcedure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connection = @"Server=VIKTOR-PC\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;TrustServerCertificate=true";

            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();

                int id = int.Parse(Console.ReadLine());

                IncreaseMinionAge(sqlConnection, id);

                var minion = GetMinion(sqlConnection, id);
                while (minion.Read())
                {
                    Console.WriteLine($"{minion[0]} – {minion[1]} years old");
                }
            }
        }

        static void IncreaseMinionAge(SqlConnection connection, int id)
        {
            string query = @"EXEC usp_GetOlder @id = @minionId";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("minionId", id);
            cmd.ExecuteNonQuery();
        }

        static SqlDataReader GetMinion(SqlConnection connection, int id)
        {
            string query = @"SELECT Name, Age FROM Minions WHERE Id = @Id";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("Id", id);

            return cmd.ExecuteReader();
        }
    }
}