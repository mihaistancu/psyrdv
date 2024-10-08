using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace psyrdv.Data;

public class OfficesRepo : IOfficesRepo
{
    private readonly string _connectionString;

    public OfficesRepo(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Azure");
    }

    public void Save(Office office)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var command = new SqlCommand("INSERT INTO offices (id, name, address) VALUES (@id, @name, @address)", connection);
            command.Parameters.AddWithValue("@id", Guid.NewGuid());
            command.Parameters.AddWithValue("@name", office.Name);
            command.Parameters.AddWithValue("@address", office.Address);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    public List<Office> GetAll()
    {
        var offices = new List<Office>();
        using (var connection = new SqlConnection(_connectionString))
        {
            var command = new SqlCommand("SELECT id, name, address FROM Offices", connection);

            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    offices.Add(new Office
                    {
                        Id = reader.GetGuid(0),
                        Name = reader.GetString(1),
                        Address = reader.GetString(2)
                    });
                }
            }
        }
        return offices;
    }

    public void Delete(Guid id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var command = new SqlCommand("DELETE FROM offices WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);

            connection.Open();
            command.ExecuteNonQuery();
        }
    }

    public Office GetById(Guid id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var command = new SqlCommand("SELECT id, name, address FROM offices WHERE id = @id", connection);
            command.Parameters.AddWithValue("@Id", id);

            connection.Open();
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new Office
                    {
                        Id = reader.GetGuid(0),
                        Name = reader.GetString(1),
                        Address = reader.GetString(2)
                    };
                }
            }
        }
        return null;
    }
}
