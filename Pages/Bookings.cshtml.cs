using Microsoft.AspNetCore.Mvc.RazorPages;
using psyrdv.Data;

namespace psyrdv.Pages;

public class BookingsModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IBookingsRepo _bookingsRepo;
    public string UserId { get; set; }

    public List<Booking> Bookings { get; set; } = new List<Booking>();
    
    public BookingsModel(ILogger<IndexModel> logger, IBookingsRepo bookingsRepo)
    {
        _logger = logger;
        _bookingsRepo = bookingsRepo;
    }

    public void OnGet()
    {
        UserId = CurrentUser.From(Request);
        
        try {
           Bookings = _bookingsRepo.getAll();
        }
        catch (Exception ex) {
            
        }
    }
}