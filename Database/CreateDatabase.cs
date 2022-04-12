using System.Data.SqlClient;

public partial class DatabaseFunctions {

    Connection con = new Connection();

    public void CreateDatabase() {

        con.OpenConnection();

        con.sql = $"CREATE DATABASE {con.dbName}";

        con.command = new SqlCommand(con.sql, con.connection);
        con.command.ExecuteNonQuery();

        con.CloseConnection();

    }

}