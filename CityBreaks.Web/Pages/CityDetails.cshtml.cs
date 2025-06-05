using CityBreaks.Web.Data;
using CityBreaks.Web.Models;
using CityBreaks.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Web.Pages;

public class CityDetailsModel : PageModel
{
    private readonly ICityService _cityService;
    private readonly CityBreaksContext _context;

    public CityDetailsModel(ICityService cityService, CityBreaksContext context)
    {
        _cityService = cityService;
        _context = context;
    }

    public City City { get; set; }

    public async Task<IActionResult> OnGetAsync(string name)
    {
        if (string.IsNullOrEmpty(name)) return NotFound();

        try
        {
            City = await _cityService.GetByNameAsync(name);

            return Page();
        }
        catch (InvalidOperationException)
        {
            return NotFound();
        }
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id, string name)
    {
        var property = await _context.Properties.FindAsync(id);

        if (property == null)
        {
            return NotFound();
        }

        property.DeletedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();

        return RedirectToPage(new { name = name });
    }
}