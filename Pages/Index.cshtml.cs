using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace psyrdv.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IAccessRepo _accessRepo;
    public string UserId { get; set; }
    public List<Access> Accesses { get; set; } = new List<Access>();

    private AccessRepo accessRepo;

    public IndexModel(ILogger<IndexModel> logger, IAccessRepo accessRepo)
    {
        _logger = logger;
        _accessRepo = accessRepo;
    }

    public void OnGet()
    {
        UserId = Request.Headers["X-MS-CLIENT-PRINCIPAL-NAME"];
        if (UserId == null) {
            UserId = "LocalDev";
        }
        
        try {
           _accessRepo.Save(UserId, DateTime.Now);
        }
        catch (Exception ex) {
            UserId += ex.Message;
        }
        
        try {
            Accesses = _accessRepo.GetAll();
        }
        catch (Exception ex) {
            UserId += ex.Message;            
        }
    }
}


