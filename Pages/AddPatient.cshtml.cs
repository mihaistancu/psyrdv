using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using psyrdv.Data;

namespace psyrdv.Pages;

public class AddPatientModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IPatientsRepo _patientsRepo;

    [BindProperty]
    public Patient Patient { get; set; }
    
    public AddPatientModel(ILogger<IndexModel> logger, IPatientsRepo patientsRepo)
    {
        _logger = logger;
        _patientsRepo = patientsRepo;
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost() {
        _patientsRepo.Save(Patient);

        return RedirectToPage("./Patients");
    }
}