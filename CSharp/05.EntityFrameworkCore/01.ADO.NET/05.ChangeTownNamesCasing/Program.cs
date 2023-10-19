using Microsoft.Data.SqlClient;

namespace _04.ChangeTownNamesCasing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connection = @"Server=VIKTOR-PC\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;TrustServerCertificate=true";

            using(SqlConnection sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();

                string country = Console.ReadLine();

                int affectedRows = UpdateTowns(sqlConnection, country);

                if (affectedRows == 0)
                {
                    Console.WriteLine("No town names were affected.");
                    return;
                }

                SqlDataReader reader = GetAllTowns(sqlConnection, country);

                Console.WriteLine($"{affectedRows} town names were affected.");

                List<string> towns = new List<string>();
                while(reader.Read()) 
                {
                    towns.Add(reader[0].ToString());
                }

                Console.WriteLine($"[{string.Join(", ", towns)}]");
            }
        }

        static int UpdateTowns(SqlConnection connection, string name)
        {
            string query = @"UPDATE Towns
                             SET Name = UPPER(Name)
                             WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue(@"countryName", name);

            return cmd.ExecuteNonQuery();
        }

        static SqlDataReader GetAllTowns(SqlConnection connection, string name)
        {
            string query = @"SELECT t.Name 
                             FROM Towns as t
                                 JOIN Countries AS c ON c.Id = t.CountryCode
                             WHERE c.Name = @countryName";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue(@"countryName", name);

            return cmd.ExecuteReader();
        }
    }
}