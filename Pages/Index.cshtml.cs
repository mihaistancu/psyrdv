using Microsoft.AspNetCore.Mvc.RazorPages;
using psyrdv.Data;

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
        UserId = CurrentUser.From(Request);
        
        try {
           _accessRepo.Save(UserId, DateTime.Now);
           Accesses = _accessRepo.GetAll();
        }
        catch (Exception ex) {
            UserId += ex.Message;
        }
    }
}


