using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using psyrdv.Data;

namespace psyrdv.Pages;

public class CreateBookingModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IBookingsRepo _bookingsRepo;

    [BindProperty]
    public Booking Booking { get; set; }
    
    public CreateBookingModel(ILogger<IndexModel> logger, IBookingsRepo bookingsRepo)
    {
        _logger = logger;
        _bookingsRepo = bookingsRepo;
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost() {
        _bookingsRepo.Save(Booking);

        return RedirectToPage("./Bookings");
    }
}