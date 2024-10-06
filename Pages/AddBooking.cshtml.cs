using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using psyrdv.Data;

namespace psyrdv.Pages;

public class AddBookingModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IBookingsRepo _bookingsRepo;
    private readonly IPatientsRepo _patientsRepo;

    [BindProperty]
    public Booking Booking { get; set; }
    public List<Patient> Patients { get; set; }

    public AddBookingModel(ILogger<IndexModel> logger, IBookingsRepo bookingsRepo, IPatientsRepo patientsRepo)
    {
        _logger = logger;
        _bookingsRepo = bookingsRepo;
        _patientsRepo = patientsRepo;
    }

    public void OnGet()
    {
        Patients = _patientsRepo.GetAll();
    }

    public IActionResult OnPost() {
        _bookingsRepo.Save(Booking);

        return RedirectToPage("./Bookings");
    }
}