using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

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
    }
}
