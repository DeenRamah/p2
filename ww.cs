//create the table
//
//CREATE TABLE SourceTable (
//    ID INT PRIMARY KEY,
//  Name NVARCHAR(255),
//   Age INT
//);

CREATE TABLE DestinationTable (
    ID INT PRIMARY KEY,
    Name NVARCHAR(255),
    Age INT
);



//C# Code to Copy Data:
using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "YourConnectionString";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Copy data from SourceTable to DestinationTable
            CopyData(connection, "SourceTable", "DestinationTable");

            Console.WriteLine("Data copied successfully.");

            // Close the connection
            connection.Close();
        }
    }

    static void CopyData(SqlConnection connection, string sourceTableName, string destinationTableName)
    {
        using (SqlCommand command = new SqlCommand($"INSERT INTO {destinationTableName} SELECT * FROM {sourceTableName}", connection))
        {
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
