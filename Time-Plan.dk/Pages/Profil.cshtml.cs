using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Differencing;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Time_Plan.dk.Pages
{
    public class ProfilModel : PageModel
    {

        public string? MedarbejderL�nNr;
        public int ffs;


        public async Task<IActionResult> OnGet()
        {
            MedarbejderL�nNr = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            ffs = Int32.Parse(MedarbejderL�nNr);

            return RedirectToPage("/Admin/Edit", new { id = ffs});
        }
    }
}
