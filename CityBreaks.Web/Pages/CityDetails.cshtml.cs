using CityBreaks.Web.Models;
using CityBreaks.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CityBreaks.Web.Pages;

public class CityDetailsModel : PageModel
{
    private readonly ICityService _cityService;

    public CityDetailsModel(ICityService cityService)
    {
        _cityService = cityService;
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
}