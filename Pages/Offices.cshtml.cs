using Microsoft.AspNetCore.Mvc.RazorPages;
using psyrdv.Data;

namespace psyrdv.Pages;

public class OfficesModel : PageModel
{
    private readonly IOfficesRepo _officeRepo;

    public OfficesModel(IOfficesRepo officesRepo)
    {
        _officeRepo = officesRepo;
    }

    public IEnumerable<Office> Offices { get; set; }

    public void OnGet()
    {
        Offices = _officeRepo.GetAll();
    }
}
