using Microsoft.Data.SqlClient;

namespace _03.AddMinion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connection = @"Server=VIKTOR-PC\SQLEXPRESS;Database=MinionsDB;Integrated Security=true;TrustServerCertificate=true";

            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();

                string[] minionData = Console.ReadLine().Split(" ").ToArray();
                string[] villianData = Console.ReadLine().Split(" ").ToArray();

                int? townId = GetTownId(sqlConnection, minionData[3]);
                
                if(townId == null)
                {
                    InsertToTowns(sqlConnection, minionData[3]);
                    townId = GetTownId(sqlConnection, minionData[3]);
                    Console.WriteLine($"Town {minionData[3]} was added to the database.");
                }

                int? villianId = GetVillianId(sqlConnection, villianData[1]);

                if(villianId == null)
                {
                    InsertToVillians(sqlConnection, villianData[1]);
                    villianId = GetVillianId(sqlConnection, villianData[1]);
                    Console.WriteLine($"Villain {villianData[1]} was added to the database.");
                }

                int? minionId = GetMinionId(sqlConnection, minionData[1], int.Parse(minionData[2]), townId);

                if (minionId == null)
                {
                    InsertToMinions(sqlConnection, minionData[1], int.Parse(minionData[2]), townId);
                    minionId = GetMinionId(sqlConnection, minionData[1], int.Parse(minionData[2]), townId);
                }

                MakeServant(sqlConnection, villianId, minionId);
                Console.WriteLine($"Successfully added {minionData[1]} to be minion of {villianData[1]}.");
            }
        }

        static int? GetTownId(SqlConnection connection, string name)
        {
            string query = @"SELECT Id FROM Towns WHERE Name = @townName";

            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("townName", name);
            int? id = (int?)sqlCommand.ExecuteScalar();

            return id;
        }

        static void InsertToTowns(SqlConnection connection, string name)
        {
            string query = @"INSERT INTO Towns (Name) VALUES (@townName)";

            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@townName", name);
            sqlCommand.ExecuteNonQuery();
        }

        static int? GetVillianId(SqlConnection connection, string name)
        {
            string query = @"SELECT Id FROM Villains WHERE Name = @Name";

            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@Name", name);

            int? id = (int?)sqlCommand.ExecuteScalar();

            return id;
        }

        static void InsertToVillians(SqlConnection connection, string name)
        {
            string query = @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@villainName", name);
            sqlCommand.ExecuteNonQuery();
        }

        static int? GetMinionId(SqlConnection connection, string name, int age, int? townId)
        {
            string query = @"SELECT Id FROM Minions WHERE Name = @Name AND Age = @Age AND TownId = @townId";

            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@Name", name);
            sqlCommand.Parameters.AddWithValue("@Age", age);
            sqlCommand.Parameters.AddWithValue("@townId", townId);

            int? id = (int?)sqlCommand.ExecuteScalar();

            return id;
        }

        static void InsertToMinions(SqlConnection connection, string name, int age, int? townId)
        {
            string query = @"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";

            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@name", name);
            sqlCommand.Parameters.AddWithValue("@age", age);
            sqlCommand.Parameters.AddWithValue("@townId", townId);

            sqlCommand.ExecuteNonQuery();
        }

        static void MakeServant(SqlConnection connection, int? villianId, int? minionId)
        {
            string query = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";

            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@minionId", minionId);
            sqlCommand.Parameters.AddWithValue("@villainId", villianId);

            sqlCommand.ExecuteNonQuery();
        }
    }
}