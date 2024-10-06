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
            "DELETE FROM bookings WHERE id = @id",
            conn);

        command.Parameters.Clear();
        command.Parameters.AddWithValue("@id", id);

        using SqlDataReader reader = command.ExecuteReader();
    }

    public List<Booking> GetAll()
    {
        var bookings = new List<Booking>();
        using var conn = new SqlConnection(connectionString);
        conn.Open();

        var command = new SqlCommand(
            "SELECT [id], [patientId], [date], [start], [end], [officeId], [details] FROM bookings",
            conn);

        using (SqlDataReader reader = command.ExecuteReader()) {
            while (reader.Read()) {
                var item = new Booking
                {
                    Id = reader.GetGuid(0),
                    PatientId = reader.GetGuid(1),
                    Date = reader.GetFieldValue<DateOnly>(2),
                    Start = reader.GetFieldValue<TimeOnly>(3),
                    End = reader.GetFieldValue<TimeOnly>(4),
                    OfficeId = reader.GetGuid(5),
                    Details = reader.GetString(6)
                };

                bookings.Add(item);
            }
        }
        return bookings;
    }

    public void Save(Booking booking)
    {
        using var conn = new SqlConnection(connectionString);
        conn.Open();

        var command = new SqlCommand(
            "INSERT INTO bookings ([id], [patientId], [date], [start], [end], [officeId], [details]) VALUES (@id, @patientId, @date, @start, @end, @officeId, @details)",
            conn);

        command.Parameters.Clear();
        command.Parameters.AddWithValue("@id", Guid.NewGuid());
        command.Parameters.AddWithValue("@patientId", booking.PatientId);
        command.Parameters.AddWithValue("@date", booking.Date);
        command.Parameters.AddWithValue("@start", booking.Start);
        command.Parameters.AddWithValue("@end", booking.End);
        command.Parameters.AddWithValue("@officeId", booking.OfficeId);
        command.Parameters.AddWithValue("@details", booking.Details);

        using SqlDataReader reader = command.ExecuteReader();
    }

    public Booking GetById(Guid id)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            var command = new SqlCommand(
                "SELECT [id], [patientId], [date], [start], [end], [officeId], [details] FROM Bookings WHERE id = @id", connection);
            command.Parameters.AddWithValue("@id", id);

            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new Booking
                    {
                        Id = reader.GetGuid(0),
                        PatientId = reader.GetGuid(1),
                        Date = reader.GetFieldValue<DateOnly>(2),
                        Start = reader.GetFieldValue<TimeOnly>(3),
                        End = reader.GetFieldValue<TimeOnly>(4),
                        OfficeId = reader.GetGuid(5),
                        Details = reader.GetString(6)
                    };
                }
            }
        }
        return null;
    }
}