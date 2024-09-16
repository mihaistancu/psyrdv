using Microsoft.Data.SqlClient;

public class AccessRepo : IAccessRepo {
    private string connectionString;

    public AccessRepo(IConfiguration configuration) {
        this.connectionString = configuration.GetConnectionString("Azure");
    }

    public void Save(string userId, DateTime timestamp) {
        using var conn = new SqlConnection(connectionString);
        conn.Open();

        var command = new SqlCommand(
            "INSERT INTO access (accessed, userid) VALUES (@accessed, @userid)",
            conn);

        command.Parameters.Clear();
        command.Parameters.AddWithValue("@accessed", DateTime.Now);
        command.Parameters.AddWithValue("@userid", userId);

        using SqlDataReader reader = command.ExecuteReader();
    }

    public List<Access> GetAll() {
        var accesses = new List<Access>();
        using var conn = new SqlConnection(connectionString);
        conn.Open();

        var command = new SqlCommand(
            "SELECT userid, accessed FROM access",
            conn);

        using (SqlDataReader reader = command.ExecuteReader()) {
            while (reader.Read()) {
                var item = new Access();
                item.UserId = reader.GetString(0);
                item.Timestamp = reader.GetDateTime(1);
                accesses.Add(item);
            }
        }
        return accesses;
    }
}