using Microsoft.Data.SqlClient;

namespace _07.IncreaseMinionAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connection = @"Server=VIKTOR-PC\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;TrustServerCertificate=true";

            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();

                int[] ids = Console.ReadLine()
                    .Split(" ")
                    .Select(id => int.Parse(id))
                    .ToArray();

                IncrementAgeOfMinion(sqlConnection, ids);
                var minions = GetAllMinions(sqlConnection);

                while(minions.Read())
                {
                    Console.WriteLine($"{minions[0]} {minions[1]}");
                }
            }
        }

        static void IncrementAgeOfMinion(SqlConnection connection, int[] ids)
        {
            string query = @"UPDATE Minions
                             SET Name = LOWER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                             WHERE Id = @Id";
            
            foreach (int id in ids)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }

        static SqlDataReader GetAllMinions(SqlConnection connection) 
        {
            string query = @"SELECT Name, Age FROM Minions";

            SqlCommand cmd = new SqlCommand(query, connection);

            return cmd.ExecuteReader();
        }
    }
}