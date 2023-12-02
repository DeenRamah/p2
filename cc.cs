//USE YourDatabase;
//GO
//CREATE PROCEDURE GetEmployeeList
//AS
//BEGIN
//    SELECT * FROM YourTable;
//END



//C# Code to Execute Stored Procedure:
using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "YourConnectionString";
        string storedProcedureName = "GetEmployeeList";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
            {
                try
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Process the retrieved data
                            Console.WriteLine($"Employee ID: {reader["EmployeeID"]}, Name: {reader["Name"]}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
