using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using psyrdv.Data;

public class DeleteOfficeModel : PageModel
{
    private readonly ILogger<DeleteOfficeModel> _logger;
    private readonly IOfficesRepo _officesRepo;

    public DeleteOfficeModel(IOfficesRepo officesRepo, ILogger<DeleteOfficeModel> logger)
    {
        this._officesRepo = officesRepo;
        this._logger = logger;
    }

    [BindProperty]
    public Guid Id { get; set; }

    public void OnGet(Guid id) {
        Id = id;
    }

    public IActionResult OnPost()
    {
        try {
            _officesRepo.Delete(Id);
        } 
        catch (Exception e) {
            _logger.LogError(e.Message);
        }
        return RedirectToPage("./Offices");
    }
}