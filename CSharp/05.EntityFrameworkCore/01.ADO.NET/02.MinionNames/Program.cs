using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace _02.MinionNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connection = @"Server=VIKTOR-PC\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;TrustServerCertificate=true";

            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();

                int villianId = int.Parse(Console.ReadLine());

                string villianNameQuery = @"SELECT Name FROM Villains WHERE Id = @Id";
                string villianMinionsQuery = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum,                                        
                                                                                             m.Name,
                                                                                             m.Age                                 
                                               FROM MinionsVillains AS mv                                   
                                                   JOIN Minions As m ON mv.MinionId = m.Id                                 
                                               WHERE mv.VillainId = @Id
                                               ORDER BY m.Name";

                using (SqlCommand sqlCommand = new SqlCommand(villianNameQuery, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@Id", villianId);

                    string villianName = (string)sqlCommand.ExecuteScalar();

                    if (villianName.IsNullOrEmpty())
                    {
                        Console.WriteLine($"No villain with ID {villianId} exists in the database.");
                        return;
                    }

                    Console.WriteLine($"Villain: {villianName}");
                }

                using (SqlCommand sqlCommand = new SqlCommand(villianMinionsQuery, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@Id", villianId);

                    SqlDataReader sqlReader = sqlCommand.ExecuteReader();

                    if (!sqlReader.HasRows)
                    {
                        Console.WriteLine($"(no minions)");
                    }
                    else
                    {
                        while (sqlReader.Read())
                        {
                            int number = int.Parse(sqlReader[0].ToString());
                            string name = sqlReader[1].ToString();
                            int age = int.Parse(sqlReader[2].ToString());

                            Console.WriteLine($"{number}. {name} {age}");
                        }
                    }
                }
            }
        }
    }
}