using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Demonstrates how to work with SqlConnection objects
/// </summary>
class SqlConnectionDemo
{
    static void Main()
    {
        // 1. Instantiate the connection
        SqlConnection conn = new SqlConnection(
            "Data Source=.\\SQLEXPRESS;Initial Catalog=testdb01;Integrated Security=SSPI;");

        SqlDataReader rdr = null;
        try
        {
            // 2. Open the connection
            conn.Open();

            // 3. Pass the connection to a command object
            SqlCommand cmd = new SqlCommand("select * from kittens", conn);

            //
            // 4. Use the connection
            //

            // get query results
            rdr = cmd.ExecuteReader();

            // print the CustomerID of each record
            while (rdr.Read())
            {
                Console.WriteLine(rdr.GetString(1));
            }
        }
        finally
        {
            // close the reader
            if (rdr != null)
            {
                rdr.Close();
            }

            // 5. Close the connection
            if (conn != null)
            {
                conn.Close();
            }
        }
    }
}
