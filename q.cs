//Code to Add a New Column:
using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "YourConnectionString";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Add a new column to the table
            AddNewColumn(connection, "YourTable", "NewColumn", "INT");

            Console.WriteLine("New column added successfully.");

            // Close the connection
            connection.Close();
        }
    }

    static void AddNewColumn(SqlConnection connection, string tableName, string columnName, string columnType)
    {
        using (SqlCommand command = new SqlCommand($"ALTER TABLE {tableName} ADD {columnName} {columnType}", connection))
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
//
//Create the Database Table (if not exists):
CREATE TABLE YourTable (
    ID INT PRIMARY KEY,
    Name NVARCHAR(255)
);
