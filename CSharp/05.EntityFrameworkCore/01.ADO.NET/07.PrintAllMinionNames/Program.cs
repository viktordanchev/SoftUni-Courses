using Microsoft.Data.SqlClient;

namespace _06.PrintAllMinionNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connection = @"Server=VIKTOR-PC\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;TrustServerCertificate=true";

            using(SqlConnection sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();

                string query = @"SELECT Name FROM Minions";

                SqlCommand cmd = new SqlCommand(query, sqlConnection);

                SqlDataReader reader = cmd.ExecuteReader();

                List<string> names = new List<string>();   
                while (reader.Read())
                {
                    names.Add(reader[0].ToString());
                }

                for (int i = 0; i < names.Count; i++)
                {
                    if(i % 2 == 1)
                    {
                        string item = names[names.Count - 1];
                        names.RemoveAt(names.Count - 1);
                        names.Insert(i, item);
                    }
                }

                Console.WriteLine(string.Join(Environment.NewLine, names));
            }
        }
    }
}