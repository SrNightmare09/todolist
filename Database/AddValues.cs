using System.Data;
using System.Data.SqlClient;

public partial class DatabaseFunctions {

    Components component = new Components();
    public DataTable dataTable;

    public void AddValues(string title, string description) {

        con.OpenConnection();

        int id = 4; //! CHANGE

        con.sql = $"USE {con.dbName}; INSERT INTO {con.tableName}(id, task_title, task_desc, delete_button) VALUES({id}, '{title}', '{description}', 'Delete');";

        con.command = new SqlCommand(con.sql, con.connection);

        con.adapter.InsertCommand = new SqlCommand(con.sql, con.connection);
        con.adapter.InsertCommand.ExecuteNonQuery();

        con.sql = "SELECT * FROM Customers";
        con.command = new SqlCommand(con.sql, con.connection);
        con.command.CommandType = CommandType.Text;

        using (con.adapter = new SqlDataAdapter(con.command)) {
            using (dataTable = new DataTable()) {
                con.adapter.Fill(dataTable);
                component.table.DataSource = dataTable;
            }
        }

        con.command.Dispose();

        con.CloseConnection();

    }

}