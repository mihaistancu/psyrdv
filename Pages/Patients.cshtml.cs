using Microsoft.AspNetCore.Mvc.RazorPages;
using psyrdv.Data;

namespace psyrdv.Pages;

public class PatientsModel : PageModel
{
    private readonly ILogger<PatientsModel> _logger;
    private readonly IPatientsRepo _patientsRepo;

    public List<Patient> Patients { get; set; } = new List<Patient>();
    
    public PatientsModel(ILogger<PatientsModel> logger, IPatientsRepo patientsRepo)
    {
        _logger = logger;
        _patientsRepo = patientsRepo;
    }

    public void OnGet()
    {
        try {
           Patients = _patientsRepo.GetAll();
        }
        catch (Exception ex) {
            _logger.LogError(ex.Message);
        }
    }
}