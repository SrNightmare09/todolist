using System.Data.SqlClient;

public partial class Connection {

    public void CloseConnection() => connection.Close();

}