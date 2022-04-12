using System;
using System.Data.SqlClient;

public partial class Connection {

    public SqlConnection connection;
    public SqlCommand command;
    public SqlDataReader reader;
    public SqlDataAdapter adapter = new SqlDataAdapter();

    public readonly string connectionString = @"";

    public string dbName = "TodoList";
    public string tableName = "Tasks";

    public string sql = string.Empty;

}