using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using psyrdv.Data;

namespace psyrdv.Pages;

public class DeletePatientModel : PageModel
{
    private readonly IPatientsRepo _patientsRepo;

    public DeletePatientModel(IPatientsRepo patientsRepo)
    {
        _patientsRepo = patientsRepo;
    }

    [BindProperty]
    public Patient Patient { get; set; }

    public IActionResult OnGet(Guid id)
    {
        Patient = _patientsRepo.GetById(id);

        if (Patient == null)
        {
            return NotFound();
        }
        return Page();
    }

    public IActionResult OnPost(Guid id)
    {
        _patientsRepo.Delete(id);

        return RedirectToPage("./Patients");
    }
}
