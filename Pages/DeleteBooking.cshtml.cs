using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using psyrdv.Data;

namespace psyrdv.Pages
{
    public class DeleteBookingModel : PageModel
    {
        private readonly IBookingsRepo _bookingsRepo;

        public DeleteBookingModel(IBookingsRepo bookingsRepo)
        {
            _bookingsRepo = bookingsRepo;
        }

        [BindProperty]
        public Booking Booking { get; set; }

        public IActionResult OnGet(Guid id)
        {
            Booking = _bookingsRepo.GetById(id);

            if (Booking == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(Guid id)
        {
            _bookingsRepo.Delete(id);

            return RedirectToPage("./Bookings");
        }
    }
}