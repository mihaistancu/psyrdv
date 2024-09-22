using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using psyrdv.Data;

namespace psyrdv.Pages;

public class AddOfficeModel : PageModel
{
    private readonly IOfficesRepo _officesRepo;

    public AddOfficeModel(IOfficesRepo officesRepo)
    {
        _officesRepo = officesRepo;
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

        _officesRepo.Save(Office);

        return RedirectToPage("./Offices");
    }
}
