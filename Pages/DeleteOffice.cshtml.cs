using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using psyrdv.Data;

public class DeleteOfficeModel : PageModel
{
    private readonly ILogger<DeleteOfficeModel> _logger;
    private readonly IOfficesRepo _officesRepo;

    [BindProperty]
    public Office Office { get; set; }

    public DeleteOfficeModel(IOfficesRepo officesRepo, ILogger<DeleteOfficeModel> logger)
    {
        this._officesRepo = officesRepo;
        this._logger = logger;
    }

    public void OnGet(Guid id) 
    {
        Office = _officesRepo.GetById(id);
    }

    public IActionResult OnPost(Guid id)
    {    
        _officesRepo.Delete(id);
        return RedirectToPage("./Offices");
    }
}