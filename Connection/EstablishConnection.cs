using System.Data;
using System.Data.SqlClient;

public partial class Connection {

    public Connection() {

        connection = new SqlConnection(connectionString);
        command = connection.CreateCommand();
        command.CommandType = CommandType.Text;

    }

}