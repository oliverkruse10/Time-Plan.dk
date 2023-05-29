using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Time_Plan.dk.Data;

namespace Time_Plan.dk.Pages.Admin
{
    
    public class EditModel : PageModel
    {
        private readonly Time_Plan.dk.Data.Time_PlandkContext _context;

        public EditModel(Time_Plan.dk.Data.Time_PlandkContext context)
        {
            _context = context;
        }
       

        [BindProperty]
        public Person Person { get; set; } = default!;

        


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Person == null)
            {
                return NotFound();
            }
            
            if (!User.IsInRole("Admin"))
            {
               if (User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value != id.ToString())
                {
                    return RedirectToPage("/AShift/Oversigt");
                }
            }
           

            var person =  await _context.Person.FirstOrDefaultAsync(m => m.ID == id);
            if (person == null)
            {
                return NotFound();
            }
            
            Person = person;
            return Page();
        }

       
        public async Task<IActionResult> OnPostAsync()
        {
           
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            
                if (_context.Person.Any(p => p.LønNr == Person.LønNr && p.ID!=Person.ID))
                {
                    ModelState.AddModelError("DuplicateLønNr", "Dette lønnummer er allerede registreret");
                    return Page();
                }
            
            
            _context.Attach(Person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(Person.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
        public IActionResult OnPostResetPassword(int id)
        {
            var person = _context.Person.FirstOrDefault(p => p.ID == id);
            if (person != null)
            {
                person.SetDefaultPassword();

                _context.SaveChanges();

                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool PersonExists(int id)
        {
          return (_context.Person?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
