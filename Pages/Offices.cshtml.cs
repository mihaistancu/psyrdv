using Microsoft.AspNetCore.Mvc.RazorPages;
using psyrdv.Data;

namespace psyrdv.Pages;

public class OfficesModel : PageModel
{
    private readonly IOfficeRepo _officeRepo;

    public OfficesModel(IOfficeRepo officeRepo)
    {
        _officeRepo = officeRepo;
    }

    public IEnumerable<Office> Offices { get; set; }

    public void OnGet()
    {
        Offices = _officeRepo.GetAll();
    }
}
