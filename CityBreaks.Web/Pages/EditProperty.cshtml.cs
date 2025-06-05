using CityBreaks.Web.Data;
using CityBreaks.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Web.Pages;

public class EditPropertyModel : PageModel
{
    private readonly CityBreaksContext _context;
    public string? FromCityName = String.Empty;

    public EditPropertyModel(CityBreaksContext context)
    {
        _context = context;
    }

    [BindProperty] public Property Property { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Property = (await _context.Properties
            .Include(p => p.City)
            .FirstOrDefaultAsync(p => p.Id == id)!)!;
        if (Property == null)
            return NotFound();

        FromCityName = Property?.City?.Name;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var propertyToUpdate = await _context.Properties.FindAsync(id);
        if (propertyToUpdate == null)
            return NotFound();

        if (!await TryUpdateModelAsync(
                propertyToUpdate,
                nameof(Property),
                p => p.Name,
                p => p.PricePerNight))
        {
            return Page();
        }

        await _context.SaveChangesAsync();
        return RedirectToPage("Index");
    }
}