using Microsoft.Data.SqlClient;

namespace psyrdv.Data;

public class BookingsRepo : IBookingsRepo
{
    private string connectionString;

    public BookingsRepo(IConfiguration configuration)
    {
        this.connectionString = configuration.GetConnectionString("Azure");
    }

    public void Delete(Guid id)
    {
        using var conn = new SqlConnection(connectionString);
        conn.Open();

        var command = new SqlCommand(
            "DELETE FROM booking WHERE id = @id",
            conn);

        command.Parameters.Clear();
        command.Parameters.AddWithValue("@id", id);

        using SqlDataReader reader = command.ExecuteReader();
    }

    public List<Booking> getAll()
    {
        var accesses = new List<Booking>();
        using var conn = new SqlConnection(connectionString);
        conn.Open();

        var command = new SqlCommand(
            "SELECT [id], [name], [date], [start], [end], [details] FROM booking",
            conn);

        using (SqlDataReader reader = command.ExecuteReader()) {
            while (reader.Read()) {
                var item = new Booking
                {
                    Id = reader.GetGuid(0),
                    Name = reader.GetString(1),
                    Date = reader.GetFieldValue<DateOnly>(2),
                    Start = reader.GetFieldValue<TimeOnly>(3),
                    End = reader.GetFieldValue<TimeOnly>(4),
                    Details = reader.GetString(5)
                };

                accesses.Add(item);
            }
        }
        return accesses;
    }

    public void Save(Booking booking)
    {
        using var conn = new SqlConnection(connectionString);
        conn.Open();

        var command = new SqlCommand(
            "INSERT INTO booking ([id], [name], [date], [start], [end], [details]) VALUES (@id, @name, @date, @start, @end, @details)",
            conn);

        command.Parameters.Clear();
        command.Parameters.AddWithValue("@id", booking.Id);
        command.Parameters.AddWithValue("@name", booking.Name);
        command.Parameters.AddWithValue("@date", booking.Date);
        command.Parameters.AddWithValue("@start", booking.Start);
        command.Parameters.AddWithValue("@end", booking.End);
        command.Parameters.AddWithValue("@details", booking.Details);

        using SqlDataReader reader = command.ExecuteReader();
    }
}