using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Differencing;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Time_Plan.dk.Pages.Account
{
    public class ProfilModel : PageModel
    {

        public string? MedarbejderLønNr;
        public int medarbejderLoggetInd;


        public async Task<IActionResult> OnGet()
        {
            MedarbejderLønNr = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            medarbejderLoggetInd = int.Parse(MedarbejderLønNr);

            return RedirectToPage("/Admin/Edit", new { id = medarbejderLoggetInd });
        }
    }
}
