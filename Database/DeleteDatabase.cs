using System.Data.SqlClient;

public partial class DatabaseFunctions {

    public void DeleteDatabase() {

        con.OpenConnection();

        con.sql = $"DROP DATABASE {con.dbName}";

        con.command = new SqlCommand(con.sql, con.connection);
        con.command.ExecuteNonQuery();

        con.CloseConnection();

    }

}