using Microsoft.AspNetCore.Mvc.RazorPages;

namespace psyrdv.Pages;

public class _LayoutModel : PageModel
{
    public string UserId { get; set; }

    public void OnGet()
    {
        UserId = CurrentUser.From(Request);
    }
}