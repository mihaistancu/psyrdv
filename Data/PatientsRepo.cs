using Microsoft.Data.SqlClient;

namespace psyrdv.Data;

public class PatientsRepo : IPatientsRepo
{
    private string connectionString;

    public PatientsRepo(IConfiguration configuration)
    {
        this.connectionString = configuration.GetConnectionString("Azure");
    }

    public void Delete(Guid id)
    {
        using var conn = new SqlConnection(connectionString);
        conn.Open();

        var command = new SqlCommand(
            "DELETE FROM patients WHERE id = @id",
            conn);

        command.Parameters.Clear();
        command.Parameters.AddWithValue("@id", id);

        using SqlDataReader reader = command.ExecuteReader();
    }

    public List<Patient> getAll()
    {
        var patients = new List<Patient>();
        using var conn = new SqlConnection(connectionString);
        conn.Open();

        var command = new SqlCommand(
            "SELECT [id], [firstName], [lastName], [NISS], [phone], [email] FROM patients",
            conn);

        using (SqlDataReader reader = command.ExecuteReader()) {
            while (reader.Read()) {
                var item = new Patient
                {
                    Id = reader.GetGuid(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Phone = reader.GetString(3),
                    Niss = reader.GetString(4),
                    Email = reader.GetString(5)
                };

                patients.Add(item);
            }
        }
        return patients;
    }

    public void Save(Patient patient)
    {
        using var conn = new SqlConnection(connectionString);
        conn.Open();

        var command = new SqlCommand(
            "INSERT INTO patients ([id], [firstName], [lastName], [niss], [phone], [email]) VALUES (@id, @firstName, @lastName, @niss, @phone, @email)",
            conn);

        command.Parameters.Clear();
        command.Parameters.AddWithValue("@id", patient.Id);
        command.Parameters.AddWithValue("@firstName", patient.FirstName);
        command.Parameters.AddWithValue("@lastName", patient.LastName);
        command.Parameters.AddWithValue("@niss", patient.Niss);
        command.Parameters.AddWithValue("@phone", patient.Phone);
        command.Parameters.AddWithValue("@email", patient.Email);

        using SqlDataReader reader = command.ExecuteReader();
    }
}
