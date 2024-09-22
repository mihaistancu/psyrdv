using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using psyrdv.Data;

namespace psyrdv.Pages;

public class CreateBookingModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IBookingsRepo _bookingsRepo;
    public string UserId { get; set; }

    [BindProperty]
    public Booking Booking { get; set; }
    
    public CreateBookingModel(ILogger<IndexModel> logger, IBookingsRepo bookingsRepo)
    {
        _logger = logger;
        _bookingsRepo = bookingsRepo;

        Booking = new Booking {
            Id = Guid.NewGuid()
        };
    }

    public void OnGet()
    {
        UserId = CurrentUser.From(Request);
    }

    public void OnPost() {
        _bookingsRepo.Save(Booking);
    }
}