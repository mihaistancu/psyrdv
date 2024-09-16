using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.Data.SqlClient;

namespace psyrdv.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public string UserId { get; set; }
    public List<Access> Accesses { get; set; } = new List<Access>();

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        UserId = Request.Headers["X-MS-CLIENT-PRINCIPAL-NAME"];
        if (UserId == null) {
            UserId = "LocalDev";
        }
        
        try {
            using var conn = new SqlConnection("Server=tcp:psyrdv.database.windows.net,1433;Initial Catalog=psyrdv;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication=\"Active Directory Default\";");
            conn.Open();

            var command = new SqlCommand(
                "INSERT INTO access (accessed, userid) VALUES (@accessed, @userid)",
                conn);

            command.Parameters.Clear();
            command.Parameters.AddWithValue("@accessed", DateTime.Now);
            command.Parameters.AddWithValue("@userid", UserId);

            using SqlDataReader reader = command.ExecuteReader();
        }
        catch (Exception ex) {
            UserId += ex.Message;            
        }
        
        try {
            using var conn = new SqlConnection("Server=tcp:psyrdv.database.windows.net,1433;Initial Catalog=psyrdv;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication=\"Active Directory Default\";");
            conn.Open();

            var command = new SqlCommand(
                "SELECT userid, accessed FROM access",
                conn);

            using (SqlDataReader reader = command.ExecuteReader()) {
                while (reader.Read()) {
                    var item = new Access();
                    item.UserId = reader.GetString(0);
                    item.Timestamp = reader.GetDateTime(1);
                    Accesses.Add(item);
                }
            }
        }
        catch (Exception ex) {
            UserId += ex.Message;            
        }
    }
}

public class Access {
    public string UserId { get; set; }
    public DateTime Timestamp { get; set; }
}
