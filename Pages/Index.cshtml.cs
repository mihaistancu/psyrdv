using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.Data.SqlClient;

namespace psyrdv.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public String UserId { get; set; }
    public String Url { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        UserId = Request.Headers["X-MS-CLIENT-PRINCIPAL-NAME"];
        
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
        
    }
}
