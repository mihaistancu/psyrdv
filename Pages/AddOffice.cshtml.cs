using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using psyrdv.Data;

namespace psyrdv.Pages;

public class AddOfficeModel : PageModel
{
    private readonly IOfficeRepo _officeRepo;

    public AddOfficeModel(IOfficeRepo officeRepo)
    {
        _officeRepo = officeRepo;
    }

    [BindProperty]
    public Office Office { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _officeRepo.Save(Office);

        return RedirectToPage("./Offices");
    }
}
