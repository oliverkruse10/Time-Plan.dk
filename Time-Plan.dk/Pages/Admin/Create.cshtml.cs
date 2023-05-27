using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using Time_Plan.dk.Data;


namespace Time_Plan.dk.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly Time_Plan.dk.Data.Time_PlandkContext _context;

        public CreateModel(Time_Plan.dk.Data.Time_PlandkContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Person Person { get; set; } = default!;



        public async Task<IActionResult> OnPostAsync()
        {
            Person.SetDefaultPassword();

            if (!ModelState.IsValid || _context.Person == null || Person == null)
            {
                return Page();
            }
                
            if (_context.Person.Any(p => p.LønNr == Person.LønNr))
            {
                ModelState.AddModelError("DuplicateLønNr", "Dette lønnummer er allerede registreret");
                return Page();
            }

            if (_context.Person.Any(p => p.SocialSecurityNumber == Person.SocialSecurityNumber))
            {
                ModelState.AddModelError("DuplicateSSN", "Dette CPR nummer er allerede registreret");
                return Page();
            }

            
            _context.Person.Add(Person);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}