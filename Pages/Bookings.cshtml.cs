using Microsoft.AspNetCore.Mvc.RazorPages;
using psyrdv.Data;

namespace psyrdv.Pages;

public class BookingsModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IBookingsRepo _bookingsRepo;
    private readonly IPatientsRepo _patientsRepo;

    public List<Booking> Bookings { get; set; } = new List<Booking>();

    public Dictionary<Guid, Patient> Patients { get; set; } = new Dictionary<Guid, Patient>();

    public BookingsModel(
        ILogger<IndexModel> logger, 
        IBookingsRepo bookingsRepo, 
        IPatientsRepo patientsRepo)
    {
        _logger = logger;
        _bookingsRepo = bookingsRepo;
        _patientsRepo = patientsRepo;
    }

    public void OnGet()
    {        
        try {
           Bookings = _bookingsRepo.GetAll();
           Patients = _patientsRepo.GetAll().ToDictionary(p => p.Id, p => p);
        }
        catch (Exception ex) {
            _logger.LogError(ex.Message);
        }
    }

    public String PatientName(Booking booking) {
        return Patients[booking.PatientId].FirstName + " " + Patients[booking.PatientId].LastName;
    }
}