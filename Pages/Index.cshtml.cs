using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace psyrdv.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        var userName = User.Identity.IsAuthenticated 
            ? "Mihai Stancu"
            : "Guest";
        
        //ViewBag.UserName = userName;
        ViewData["UserName"] = userName;
    }
}
