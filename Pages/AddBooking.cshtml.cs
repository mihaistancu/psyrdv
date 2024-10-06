using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using psyrdv.Data;

namespace psyrdv.Pages;

public class AddBookingModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IBookingsRepo _bookingsRepo;
    private readonly IPatientsRepo _patientsRepo;
    private readonly IOfficesRepo _officesRepo;

    [BindProperty]
    public Booking Booking { get; set; }
    public List<Patient> Patients { get; set; }
    public List<Office> Offices { get; set; }

    public AddBookingModel(
        ILogger<IndexModel> logger, 
        IBookingsRepo bookingsRepo, 
        IPatientsRepo patientsRepo,
        IOfficesRepo officesRepo)
    {
        _logger = logger;
        _bookingsRepo = bookingsRepo;
        _patientsRepo = patientsRepo;
        _officesRepo = officesRepo;
    }

    public void OnGet()
    {
        Patients = _patientsRepo.GetAll();
        Offices = _officesRepo.GetAll();
    }

    public IActionResult OnPost() {
        _bookingsRepo.Save(Booking);

        return RedirectToPage("./Bookings");
    }
}