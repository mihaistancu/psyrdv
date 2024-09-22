using Microsoft.AspNetCore.Mvc.RazorPages;
using psyrdv.Data;

namespace psyrdv.Pages;

public class BookingsModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IBookingsRepo _bookingsRepo;

    public List<Booking> Bookings { get; set; } = new List<Booking>();
    
    public BookingsModel(ILogger<IndexModel> logger, IBookingsRepo bookingsRepo)
    {
        _logger = logger;
        _bookingsRepo = bookingsRepo;
    }

    public void OnGet()
    {        
        try {
           Bookings = _bookingsRepo.GetAll();
        }
        catch (Exception ex) {
            _logger.LogError(ex.Message);
        }
    }
}