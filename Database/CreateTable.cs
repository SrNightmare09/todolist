using System.Data.SqlClient;

public partial class DatabaseFunctions {

    public void CreateTable() {

        con.OpenConnection();

        con.sql = $"USE {con.dbName}; CREATE TABLE {con.tableName} (id INTEGER NOT NULL, task_title TEXT NOT NULL, task_desc TEXT NOT NULL, delete_button TEXT NOT NULL);";

        con.command = new SqlCommand(con.sql, con.connection);
        con.command.ExecuteNonQuery();

        con.CloseConnection();

    }

}