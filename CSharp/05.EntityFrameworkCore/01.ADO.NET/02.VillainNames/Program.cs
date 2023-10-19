using Microsoft.Data.SqlClient;

namespace VillainNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connection = @"Server=VIKTOR-PC\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;TrustServerCertificate=true";

            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();

                string query = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount 
                                 FROM Villains AS v 
                                     JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
                                 GROUP BY v.Id, v.Name 
                                 HAVING COUNT(mv.VillainId) > 3 
                                 ORDER BY COUNT(mv.VillainId)";

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    SqlDataReader sqlReader = sqlCommand.ExecuteReader();

                    while (sqlReader.Read())
                    {
                        string name = sqlReader[0].ToString();
                        string count = sqlReader[1].ToString();
                        Console.WriteLine($"{name} - {count}");
                    }
                }
            }
        }
    }
}